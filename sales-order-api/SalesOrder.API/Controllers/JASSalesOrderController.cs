using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesOrder.API.Helpers;
using SalesOrder.Service.Interfaces;
using SalesOrder.Shared.DTOs;
using SalesOrder.Shared.DTOs.JAS;
using Serilog;

namespace SalesOrder.API.Controllers
{
    [ApiController]
    [Route("api/jas-sales-order")]
    public class JASSalesOrderController : Controller
    {
        private readonly IJASSalesService _service;
        private string errorFileName = $"FAILED_SALES_ORDER_{DateTime.Now.ToString("yyyyMMdd").ToUpper()}.json";

        public JASSalesOrderController(IJASSalesService service)
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
                // Deserialize the file & validate data
                ValidateDeserilializeResultDTO resultValidate = await _service.ValidateDeserilializeRequest(salesOrder);
                if (!resultValidate.IsValid || resultValidate.Messages.Count() > 0)
                {
                    return Ok(new SalesOrderResponseDTO()
                    {
                        IsValid = false,
                        FileName = errorFileName,
                        Data = ResponseSerializer.CreateFailedResponseJsonFile(resultValidate.Messages, errorFileName)
                    });
                }

                // Create response object
                GenerateSalesOrderResultDTO resultGenerate = await _service.GenerateExpectedSalesOrder(resultValidate.Request.SalesOrderRequest);
                if (!resultGenerate.IsValid || resultGenerate.Messages.Count() > 0)
                {
                    return Ok(new SalesOrderResponseDTO()
                    {
                        IsValid = false,
                        FileName = errorFileName,
                        Data = ResponseSerializer.CreateFailedResponseJsonFile(resultGenerate.Messages, errorFileName)
                    });
                }

                // successFileName = [orderRef]-[categoryCode]-[currentDate].json
                string successFileName = $"{resultGenerate.Response.Order.OrderRef.ToUpper()}-{resultGenerate.Response.Order.CategoryCode.ToUpper()}-{DateTime.Now.ToString("yyyyMMdd").ToUpper()}.json";

                // Create Expected Sales Order
                return Ok(new SalesOrderResponseDTO()
                {
                    IsValid = true,
                    FileName = successFileName,
                    Data = ResponseSerializer.CreateSuccessResponseJsonFile(resultGenerate.Response, successFileName)
                });
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

// result - boolean, fileName, object, message[] 