using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesOrder.API.Helpers;
using SalesOrder.Service.Interfaces;
using SalesOrder.Shared.DTOs;
using Serilog;

namespace SalesOrder.API.Controllers
{
    [ApiController]
    [Route("api/sales-order")]
    public class SalesOrderController : Controller
    {
        private readonly ISalesOrderService _service;

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
                // Default
                string errorFileName = $"sales_order_response_{DateTime.Now.ToString("yyyyMMdd")}.json";

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

                // TODO: Generate success file
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

                return Ok(new SalesOrderResponseDTO() { IsValid = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest();
            }
        }
    }
}