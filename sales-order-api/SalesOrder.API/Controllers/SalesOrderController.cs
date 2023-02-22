using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesOrder.API.Helpers;
using SalesOrder.Service.Interfaces;
using SalesOrder.Shared.DTOs;
using SalesOrder.Shared.Models;
using Serilog;

namespace SalesOrder.API.Controllers
{
    [ApiController]
    [Route("api/sales-order")]
    public class SalesOrderController : Controller
    {
        private readonly ISalesOrderService _service;
        private string errorFileName = $"FAILED_SALES_ORDER_{DateTime.Now.ToString("yyyyMMdd").ToUpper()}.json";

        public SalesOrderController(ISalesOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("upload")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload([FromForm] IFormFile salesOrder)
        {
            try
            {
                // Validate file & length
                SalesOrderResultDTO isValidFile = await _service.ValidateSalesOrderFile(salesOrder);
                if (!isValidFile.IsValid)
                {
                    // Return response with invalid & messages
                    return Ok(new SalesOrderResponseDTO()
                    {
                        IsValid = false,
                        FileName = errorFileName,
                        Data = ResponseSerializer.CreateFailedResponseJsonFile(isValidFile.Messages, errorFileName)
                    });
                }

                // Try to deserialize json contents to DTO
                SalesOrderResultDTO isValidDTO = await _service.DeseriliazeSalesOrder(salesOrder);
                if (!isValidDTO.IsValid)
                {
                    // Return response with invalid & messages
                    return Ok(new SalesOrderResponseDTO()
                    {
                        IsValid = false,
                        FileName = errorFileName,
                        Data = ResponseSerializer.CreateFailedResponseJsonFile(isValidDTO.Messages, errorFileName)
                    });
                }

                // Validate data from json file
                List<MessageDTO> validateResult = await _service.ValidateSalesOrder((SalesOrderRequestDTO)isValidDTO.SalesOrder);
                if (validateResult.Count() > 0)
                {
                    // Return response with invalid & messages
                    return Ok(new SalesOrderResponseDTO()
                    {
                        IsValid = false,
                        FileName = errorFileName,
                        Data = ResponseSerializer.CreateFailedResponseJsonFile(validateResult, errorFileName)
                    });
                }

                // Database operation
                var validOperation = await _service.ProcessSalesOrder((SalesOrderRequestDTO)isValidDTO.SalesOrder);
                if (!validOperation.IsValid)
                {
                    return Ok(new SalesOrderResponseDTO()
                    {
                        IsValid = false,
                        FileName = errorFileName,
                        Data = ResponseSerializer.CreateFailedResponseJsonFile(validateResult, errorFileName)
                    });
                }
                else
                {
                    // Create successful result
                    Order succssOrder = (Order)validOperation.SalesOrder;
                    string successFileName = $"{succssOrder.OrderCode}_{succssOrder.Category.CategoryCode}_{DateTime.Now.ToString("yyyyMMdd").ToUpper()}.json";
                    return Ok(new SalesOrderResponseDTO()
                    {
                        IsValid = true,
                        FileName = successFileName,
                        Data = ResponseSerializer.CreateSuccessResponseJsonFile(succssOrder, successFileName)
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                // BadRequest with object
                List<MessageDTO> messages = new List<MessageDTO>
                { new MessageDTO { Id = 1, Message = ex.Message } };
                return BadRequest(new SalesOrderResponseDTO()
                {
                    IsValid = false,
                    FileName = errorFileName,
                    Data = ResponseSerializer.CreateFailedResponseJsonFile(messages, errorFileName)
                });
            }
        }
    }
}