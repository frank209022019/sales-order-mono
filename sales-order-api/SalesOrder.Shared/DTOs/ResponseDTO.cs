using Newtonsoft.Json;
using SalesOrder.Shared.Models;

namespace SalesOrder.Shared.DTOs
{
    public class SalesOrderResponseDTO
    {
        public bool IsValid { get; set; }
        public string ResponseDate { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }

        public SalesOrderResponseDTO()
        {
            ResponseDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }
    }

    #region Failed

    public class FailedResponseStructureDTO
    {
        // Result & Messages

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("messages")]
        public List<MessageDTO> Messages { get; set; }

        public FailedResponseStructureDTO(List<MessageDTO> messages)
        {
            Result = "FAILED";
            Messages = messages;
        }
    }

    #endregion Failed

    #region Success

    public class SuccessResponseStructureDTO
    {
        // User
        [JsonProperty("userCode")]
        public string UserCode { get; set; }

        [JsonProperty("userFullName")]
        public string UserFullName { get; set; }

        // Order
        [JsonProperty("orderCode")]
        public string OrderCode { get; set; }

        [JsonProperty("orderDate")]
        public string OrderDate { get; set; }

        // Customer
        [JsonProperty("customerCode")]
        public string CustomerCode { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("customerEmail")]
        public string CustomerEmail { get; set; }

        [JsonProperty("customerContact")]
        public string CustomerContact { get; set; }

        // Address
        [JsonProperty("shippingAddress")]
        public string ShippingAddress { get; set; }

        [JsonProperty("billingAddress")]
        public string BillingAddress { get; set; }

        // Order summary
        [JsonProperty("vatPercentage")]
        public string VATPercentage { get; set; }

        [JsonProperty("totalProduct")]
        public decimal TotalProduct { get; set; }

        [JsonProperty("subTotal")]
        public decimal SubTotal { get; set; }

        [JsonProperty("taxTotal")]
        public decimal TaxTotal { get; set; }

        [JsonProperty("orderTotal")]
        public decimal OrderTotal { get; set; }

        // Result & Messages

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("messages")]
        public List<MessageDTO> Messages { get; set; }

        // Products
        [JsonProperty("products")]
        public List<OrderProductDTO> Products { get; set; }

        public SuccessResponseStructureDTO(Order order)
        {
            UserCode = order.User.UserCode;
            UserFullName = $"{order.User.LastName}, {order.User.FirstName}";

            OrderCode = order.OrderCode;
            OrderDate = order.DateCreated.ToString("yyyy-MM-dd HH:mm");

            CustomerCode = order.Customer.CustomerCode;
            CustomerName = order.Customer.Name;
            CustomerEmail = order.Customer.Email;
            CustomerContact = order.Customer.ContactNumber;

            ShippingAddress = order.Customer.Address;
            BillingAddress = order.Customer.Address;

            VATPercentage = order.VAT;
            TotalProduct = order.ProductTotal;
            SubTotal = order.SubTotal;
            TaxTotal = order.TaxAmount;
            OrderTotal = order.Total;

            Result = "SUCCESS";
            Messages = new List<MessageDTO>
            {
                new MessageDTO { Id = 1, Message = "Sales order completed successfully" }
            };

            Products = new List<OrderProductDTO>();
            foreach (var prod in order.OrderProducts)
            {
                Products.Add(new OrderProductDTO()
                {
                    ProductCode = prod.Product.ProductCode,
                    Name = prod.Product.Name,
                    Price = prod.Product.Price,
                    Quantity = prod.Quantity,
                    SubTotal = prod.SubTotal,
                    TaxTotal = prod.TaxAmount,
                    Total = prod.Total,
                });
            }
        }
    }

    #endregion Success
}