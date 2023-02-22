using Newtonsoft.Json;

namespace SalesOrder.Shared.DTOs
{
    #region DTO

    public class SalesOrderRequestDTO
    {
        [JsonProperty("userCode")]
        public string UserCode { get; set; }

        [JsonProperty("categoryCode")]
        public string CategoryCode { get; set; }

        [JsonProperty("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonProperty("customerCode")]
        public string CustomerCode { get; set; }

        [JsonProperty("products")]
        public List<SalesOrderProductRequestDTO> Products { get; set; }
    }

    public class SalesOrderProductRequestDTO
    {
        [JsonProperty("productCode")]
        public string ProductCode { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }

    #endregion DTO

    #region Validate-Deserilialize-Process

    public class SalesOrderResultDTO
    {
        public bool IsValid { get; set; }
        public List<MessageDTO> Messages { get; set; }
        public object? SalesOrder { get; set; } //  SalesOrderRequestDTO || Order

        public SalesOrderResultDTO()
        {
            Messages = new List<MessageDTO>();
        }
    }

    #endregion Validate-Deserilialize-Process
}