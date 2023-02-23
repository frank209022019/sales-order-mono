using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SalesOrder.Service.Interfaces;
using SalesOrder.Shared.DTOs;
using SalesOrder.Shared.DTOs.JAS;

namespace SalesOrder.Service.Services
{
    public class JASSalesService : IJASSalesService
    {
        public JASSalesService()
        {
        }

        /// <summary>
        /// Convert incoming sales order JSON file to a class.
        /// </summary>
        public async Task<ValidateDeserilializeResultDTO?> ValidateDeserilializeRequest(IFormFile file)
        {
            // Result
            var result = new ValidateDeserilializeResultDTO() { Request = new JASSalesOrderRequestRootDTO() };
            int messageId = 1;
            try
            {
                // Valid incoming file
                if (file == null || file.Length == 0)
                {
                    WriteMessage(result.Messages, messageId, "The sales order file does not meet the required validation");
                    return result;
                }

                // Read file with StreamReader
                string fileContent = null;
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    fileContent = reader.ReadToEnd();
                }
                if (fileContent == null || fileContent.Length == 0)
                {
                    WriteMessage(result.Messages, messageId, $"Failed to read the contents of {file.FileName}.");
                    return result;
                }

                // Deserialize to DTO
                result.Request = JsonConvert.DeserializeObject<JASSalesOrderRequestRootDTO>(fileContent);
                if (result.Request == null)
                {
                    WriteMessage(result.Messages, messageId, $"Failed to deserialize the contents of {file.FileName}.");
                    return result;
                }

                result.IsValid = result.Messages.Count() == 0 ? true : false;
                return result;
            }
            catch (Exception ex)
            {
                WriteMessage(result.Messages, messageId, ex.Message);
                return result;
            }
        }

        /// <summary>
        /// Use the request model to create the appropriate response model for the expected sales order.
        /// </summary>
        public async Task<GenerateSalesOrderResultDTO?> GenerateExpectedSalesOrder(JASSalesOrderRequestDTO request)
        {
            // Result
            var result = new GenerateSalesOrderResultDTO { Response = new JASSalesOrderResponseDTO() };
            int messageId = 1;
            try
            {
                // SalesOrder
                if (request.SalesOrder.SalesOrderRef == null || request.SalesOrder.OrderDate == null
                    || request.SalesOrder.Currency == null || request.SalesOrder.ShipDate == null || request.SalesOrder.CategoryCode == null)
                {
                    WriteMessage(result.Messages, messageId, "One or more values within the SalesOrder is invalid.");
                    messageId++;
                }
                else
                {
                    result.Response.Order.OrderRef = request.SalesOrder.SalesOrderRef ?? string.Empty;
                    result.Response.Order.OrderDate = request.SalesOrder.OrderDate ?? string.Empty;
                    result.Response.Order.Currency = request.SalesOrder.Currency ?? string.Empty;
                    result.Response.Order.ShipDate = request.SalesOrder.ShipDate ?? string.Empty;
                    result.Response.Order.CategoryCode = request.SalesOrder.CategoryCode ?? string.Empty;
                }

                // Addresses
                if (request.SalesOrder.Addresses == null || request.SalesOrder.Addresses.Count() == 0)
                {
                    WriteMessage(result.Messages, messageId, "No addresses found for the sales order.");
                    messageId++;
                }
                else
                {
                    foreach (var address in request.SalesOrder.Addresses)
                    {
                        var temp = new ResponseAddressDTO
                        {
                            //AddressType = address.AddressType ?? string.Empty,
                            LocationNumber = (int?)address.LocationNumber ?? 0,
                            ContactName = address.ContactName ?? string.Empty,
                            LastName = address.LastName ?? string.Empty,
                            CompanyName = address.CompanyName ?? string.Empty,
                            AddressLine1 = address.AddressLine1 ?? string.Empty,
                            AddressCity = address.City ?? string.Empty,
                            AddressState = address.State ?? string.Empty,
                            Postcode = (int?)address.Postcode ?? 0,
                            CountryCode = address.CountryCode ?? string.Empty,
                            PhoneNumber = address.PhoneNumber ?? string.Empty,
                            EmailAddress = address.EmailAddress ?? string.Empty,
                        };

                        // Determine address type
                        switch (address.AddressType)
                        {
                            case null:
                                temp.AddressType = string.Empty;
                                break;
                            case "BillTo":
                                temp.AddressType = "BY";
                                break;
                            case "ShipTo":
                                temp.AddressType = "ST";
                                break;
                            default:
                                temp.AddressType = string.Empty;
                                break;
                        }

                        result.Response.Order.Addresses.Add(temp);
                    }
                }

                // OrderLines
                if (request.SalesOrder.Addresses == null || request.SalesOrder.Addresses.Count() == 0)
                {
                    WriteMessage(result.Messages, messageId, "No order lines found for the sales order.");
                    messageId++;
                }
                else
                {
                    foreach (var orderLine in request.SalesOrder.OrderLines)
                    {
                        result.Response.Order.Lines.Add(new ResponseOrderLineDTO
                        {
                            Sku = orderLine.SkuCode ?? string.Empty,
                            Qty = (int?)orderLine.Quantity ?? 0,
                            Desc = orderLine.Description ?? string.Empty,
                        });
                    }
                }

                result.IsValid = result.Messages.Count() == 0 ? true : false;
                return result;
            }
            catch (Exception ex)
            {
                WriteMessage(result.Messages, messageId, ex.Message);
                return result;
            }
        }

        #region Utilities

        private void WriteMessage(List<MessageDTO> messages, int messageId, string message)
        {
            messages.Add(new MessageDTO { Id = messageId, Message = message });
        }

        #endregion Utilities
    }
}