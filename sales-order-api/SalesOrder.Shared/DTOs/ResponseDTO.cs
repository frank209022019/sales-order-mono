using Newtonsoft.Json;

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
        [JsonProperty("result")]
        public string Result { get; set; }

        public string ResponseDate { get; set; }

        [JsonProperty("messages")]
        public List<MessageDTO> Messages { get; set; }

        public SuccessResponseStructureDTO(List<MessageDTO> messages)
        {
            Result = "SUCCESS";
            Messages = messages;
        }
    }

    #endregion Success
}