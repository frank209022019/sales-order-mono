using Newtonsoft.Json;

namespace SalesOrder.Shared.DTOs
{
    public class OrderProductDTO
    {
        [JsonProperty("productCode")]
        public string ProductCode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("subTotal")]
        public decimal SubTotal { get; set; }
        [JsonProperty("taxTotal")]
        public decimal TaxTotal { get; set; }
        [JsonProperty("total")]
        public decimal Total { get; set; }
    }
}