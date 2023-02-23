namespace SalesOrder.Shared.DTOs.JAS
{
    /// <summary>
    /// Result DTO for validating and deserializing the incoming JSON file.
    /// </summary>
    public class ValidateDeserilializeResultDTO
    {
        public bool IsValid { get; set; }
        public List<MessageDTO> Messages { get; set; }

        public JASSalesOrderRequestRootDTO? Request { get; set; }

        public ValidateDeserilializeResultDTO()
        {
            IsValid = false;
            Messages = new List<MessageDTO>();
            Request = null;
        }
    }

    /// <summary>
    /// Result DTO for generating the expected sales order data model.
    /// </summary>
    public class GenerateSalesOrderResultDTO
    {
        public bool IsValid { get; set; }
        public List<MessageDTO> Messages { get; set; }

        public JASSalesOrderResponseDTO? Response { get; set; }

        public GenerateSalesOrderResultDTO()
        {
            IsValid = false;
            Messages = new List<MessageDTO>();
            Response = null;
        }
    }
}