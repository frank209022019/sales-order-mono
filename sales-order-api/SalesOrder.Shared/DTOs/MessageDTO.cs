using Newtonsoft.Json;

namespace SalesOrder.Shared.DTOs
{
    public class MessageDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}