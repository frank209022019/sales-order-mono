using Newtonsoft.Json;

namespace SalesOrder.Shared.DTOs.JAS
{
    public class ResponseAddressDTO
    {
        [JsonProperty("addressType")]
        public string AddressType { get; set; }

        [JsonProperty("locationNumber")]
        public int LocationNumber { get; set; }

        [JsonProperty("contactName")]
        public string ContactName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressCity")]
        public string AddressCity { get; set; }

        [JsonProperty("addressState")]
        public string AddressState { get; set; }

        [JsonProperty("postcode")]
        public int Postcode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }

    public class ResponseOrderLineDTO
    {
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("qty")]
        public int Qty { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }
    }

    public class ResponseOrderDTO
    {
        [JsonProperty("orderRef")]
        public string OrderRef { get; set; }

        [JsonProperty("orderDate")]
        public string OrderDate { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("shipDate")]
        public string ShipDate { get; set; }

        [JsonProperty("categoryCode")]
        public string CategoryCode { get; set; }

        [JsonProperty("addresses")]
        public List<ResponseAddressDTO> Addresses { get; set; }

        [JsonProperty("lines")]
        public List<ResponseOrderLineDTO> Lines { get; set; }
    }

    public class JASSalesOrderResponseDTO
    {
        [JsonProperty("order")]
        public ResponseOrderDTO Order { get; set; }

        public JASSalesOrderResponseDTO()
        {
            Order = new ResponseOrderDTO()
            {
                Addresses = new List<ResponseAddressDTO>(),
                Lines = new List<ResponseOrderLineDTO>()
            };
        }
    }
}