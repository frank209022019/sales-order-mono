using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesOrder.Service.Interfaces;
using SalesOrder.Shared.DTOs;
using Serilog;

namespace SalesOrder.API.Controllers
{
    //public class MyResponseModel
    //{
    //    public bool Success { get; set; }
    //    public string RequestMessage { get; set; }
    //    public Byte[] JsonData { get; set; }
    //}

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
                // Validate file & length
                var isValidFile = await _service.ValidateSalesOrderFile(salesOrder);
                if (!isValidFile.IsValid)
                {
                    // TODO: Return response with invalid & messages
                }

                // Try to deserialize json contents to DTO
                var isValidDTO = await _service.DeseriliazeSalesOrder(salesOrder);
                if (!isValidFile.IsValid)
                {
                    // TODO: Return response with invalid & messages
                }

                // Validate data from json file
                var validateResult = await _service.ValidateSalesOrder(isValidDTO.SalesOrder);
                if(validateResult.Count() > 0)
                {
                    // TODO: Return response with invalid & messages
                }


                // process the uploaded file here
                // return a proper response model & byte[]

                // create a response model
                //var responseModel = new MyResponseModel
                //{
                //    Success = true,
                //    RequestMessage = "Some request message",
                //    JsonData = new byte[salesOrder.Length]
                //};

                //// read the file into a byte array
                //using (var stream = new MemoryStream())
                //{
                //    await salesOrder.CopyToAsync(stream);
                //    responseModel.JsonData = stream.ToArray();
                //}

                return Ok();

                // return the response as a JSON file
                //return File(responseModel.JsonData, "application/json", "myfile.json");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest();
            }
        }
    }
}