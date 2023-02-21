using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SalesOrder.Database;
using SalesOrder.Database.Models;
using SalesOrder.Service.Helpers;
using SalesOrder.Service.Interfaces;
using SalesOrder.Shared.DTOs;
using SalesOrder.Shared.Utilities;
using Serilog;

namespace SalesOrder.Service.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly SalesContext _context;

        public SalesOrderService(SalesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Function to validate the incoming file.
        /// </summary>
        public async Task<ValidateDeserilalizeResultDTO> ValidateSalesOrderFile(IFormFile salesOrder)
        {
            try
            {
                var result = new ValidateDeserilalizeResultDTO() { IsValid = false, SalesOrder = null };
                if (salesOrder == null || salesOrder.Length == 0)
                {
                    // Invalid
                    result.Messages.Add(new MessageDTO() { Id = 1, Message = "The file does not meet the required validation" });
                    return result;
                }

                // Valid
                result.IsValid = true;
                return result;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                // Failure to validate salesOrder
                var result = new ValidateDeserilalizeResultDTO() { IsValid = false, SalesOrder = null };
                result.Messages.Add(new MessageDTO() { Id = 1, Message = "Failed to validate incoming sales order file." });
                result.Messages.Add(new MessageDTO() { Id = 2, Message = ex.InnerException.Message });
                return result;
            }
        }

        /// <summary>
        /// Function used to deserialize the incoming sales order to ensure the correct format is implemented in the file.
        /// </summary>
        public async Task<ValidateDeserilalizeResultDTO> DeseriliazeSalesOrder(IFormFile salesOrder)
        {
            try
            {
                // Read file
                string fileContent = null;
                using (var reader = new StreamReader(salesOrder.OpenReadStream()))
                {
                    fileContent = reader.ReadToEnd();
                }

                // Deserialize to DTO
                var result = JsonConvert.DeserializeObject<SalesOrderRequestDTO>(fileContent);

                // Return DTO
                return new ValidateDeserilalizeResultDTO() { IsValid = true, SalesOrder = result };
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                // Failure to deserialze salesOrder
                var result = new ValidateDeserilalizeResultDTO() { IsValid = false, SalesOrder = null };
                result.Messages.Add(new MessageDTO() { Id = 1, Message = "Failed to deserialze incoming sales order structure." });
                result.Messages.Add(new MessageDTO() { Id = 2, Message = ex.InnerException.Message });
                return result;
            }
        }

        /// <summary>
        /// Function used to apply the required validations against the sales order request.
        /// </summary>
        public async Task<List<MessageDTO>> ValidateSalesOrder(SalesOrderRequestDTO salesOrder)
        {
            try
            {
                List<MessageDTO> messages = new List<MessageDTO>();
                int currentMessageId = 1;

                // 1. Valid user code
                if (!_context.Users.Where(i => i.IsActive).Any())
                {
                    messages.Add(new MessageDTO() { Id = currentMessageId, Message = "Invalid user code in sales order" });
                    currentMessageId++;
                }

                // 2. Valid category code
                if (!_context.Categories.Where(i => i.IsActive).Any())
                {
                    messages.Add(new MessageDTO() { Id = currentMessageId, Message = "Invalid category code in sales order" });
                    currentMessageId++;
                }

                // 3. Valid order date (between current date & 7 days before)
                if (!(salesOrder.OrderDate >= DateTime.Now.AddDays(-7) && salesOrder.OrderDate <= DateTime.Now))
                {
                    messages.Add(new MessageDTO() { Id = currentMessageId, Message = "Invalid date or date format in sales order" });
                    currentMessageId++;
                }

                // 4. Valid customer code
                if (!_context.Categories.Where(i => i.IsActive).Any())
                {
                    messages.Add(new MessageDTO() { Id = currentMessageId, Message = "Invalid category code in sales order" });
                    currentMessageId++;
                }

                // 5. Valid count of products ( products > 1)
                if (!salesOrder.Products.Any())
                {
                    messages.Add(new MessageDTO() { Id = currentMessageId, Message = "No products in sales order" });
                    currentMessageId++;
                }

                // 6. Product validation - valid product code, quantity
                if (salesOrder.Products.Any())
                {
                    var products = _context.Products.Where(i => !i.IsActive).ToList();
                    salesOrder.Products.ForEach((SalesOrderProductRequestDTO prod) =>
                    {
                        if (prod.Quantity < 1 || !products.Where(i => i.ProductCode == prod.ProductCode).Any())
                        {
                            messages.Add(new MessageDTO() { Id = currentMessageId, Message = $"Invalid product code or quantity for {prod.ProductCode ?? "NO_PRODUCT_CODE"}" });
                            currentMessageId++;
                        }
                    });
                }

                return messages;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                // Failure to validate salesOrder
                var result = new List<MessageDTO>();
                result.Add(new MessageDTO() { Id = 1, Message = "Failed to validate incoming sales order data." });
                result.Add(new MessageDTO() { Id = 2, Message = ex.InnerException.Message });
                return result;
            }
        }

        /// <summary>
        /// Function to process the sales order once validation is complete.
        /// </summary>
        public async Task<bool> ProcessSalesOrder(SalesOrderRequestDTO salesOrder)
        {
            try
            {
                // Collections
                var users = _context.Users.Where(i => i.IsActive).ToList();
                var customers = _context.Customers.Where(i => i.IsActive).ToList();
                var products = _context.Products.Where(i => i.IsActive).ToList();
                var categories = _context.Categories.Where(i => i.IsActive).ToList();

                // Create Order record
                Order order = new Order()
                {
                    Id = Guid.NewGuid(),
                    User = users.FirstOrDefault(i => i.UserCode == salesOrder.UserCode),
                    Category = categories.FirstOrDefault(i => i.CategoryCode == salesOrder.CategoryCode),
                    Customer = customers.FirstOrDefault(i => i.CustomerCode == salesOrder.CustomerCode),
                    CreatedById = SalesOrderContstants.UserId1,
                    DateCreated = DateTime.Now,
                    OrderCode = OrderHelper.GenerateOrderCode(),
                    ProductTotal = salesOrder.Products.Count(),
                    SubTotal = 0,
                    TaxAmount = 0,
                    Total = 0,
                };

                // Create OrderProduct record/s
                List<OrderProduct> orderProducts = new List<OrderProduct>();
                foreach(var product in salesOrder.Products)
                {
                    // Work out financials
                    var currentPrice = products.FirstOrDefault(i => i.ProductCode == product.ProductCode).Price;
                    var total = currentPrice * product.Quantity;
                    var tax = (SalesOrderContstants.VATPercentage / 100) * total;

                    // Create model
                    OrderProduct temp = new OrderProduct()
                    {
                        Id = Guid.NewGuid(),
                        CreatedById = SalesOrderContstants.UserId1,
                        DateCreated = DateTime.Now,
                        Quantity = product.Quantity,
                        CurrentProductPrice = currentPrice,
                        Total = total,
                        TaxAmount = tax,
                        SubTotal = total - tax,
                        VAT = SalesOrderContstants.VATPercentage.ToString().ToUpper(),
                    };
                    orderProducts.Add(temp);
                }

                // Update order total
                order.Total = orderProducts.Sum(i => i.Total);
                order.TaxAmount = orderProducts.Sum(i => i.TaxAmount);
                order.SubTotal = orderProducts.Sum(i => i.SubTotal);

                // Save to database
                _context.Orders.Add(order);
                _context.OrderProducts.AddRange(orderProducts);
                _context.SaveChanges();

                // Create result with object to serialize to JSON, messages

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                // Failure to process salesOrder
                var result = new List<MessageDTO>();
                result.Add(new MessageDTO() { Id = 1, Message = "Failed to process sales order data." });
                result.Add(new MessageDTO() { Id = 2, Message = ex.InnerException.Message });
                return false;
            }
        }
    }
}