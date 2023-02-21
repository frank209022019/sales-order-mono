using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace SalesOrder.API.Controllers
{
    public class MyResponseModel
    {
        public bool Success { get; set; }
        public string RequestMessage { get; set; }
        public Byte[] JsonData { get; set; }
    }

    [ApiController]
    [Route("api/sales-order")]
    public class SalesOrderController : Controller
    {
        [HttpPost]
        [Route("upload")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload([FromForm] IFormFile salesOrder)
        {
            try
            {
                if (salesOrder == null || salesOrder.Length == 0)
                {
                    return BadRequest("Please select a file for upload");
                }

                // process the uploaded file here
                // return a proper response model & byte[]

                // create a response model
                var responseModel = new MyResponseModel
                {
                    Success = true,
                    RequestMessage = "Some request message",
                    JsonData = new byte[salesOrder.Length]
                };

                // read the file into a byte array
                using (var stream = new MemoryStream())
                {
                    await salesOrder.CopyToAsync(stream);
                    responseModel.JsonData = stream.ToArray();
                }

                return Ok(responseModel);

                // return the response as a JSON file
                //return File(responseModel.JsonData, "application/json", "myfile.json");
            }
            catch (Exception ex) 
            {
                Log.Error(ex.Message);
                return BadRequest(new MyResponseModel() { Success = false, RequestMessage = ex.Message, JsonData = null });
            }
        }
    }
}