using Newtonsoft.Json;

namespace SalesOrder.Shared.DTOs.JAS
{
    public class RequestAddressDTO
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

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postcode")]
        public int Postcode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("locationNumberQualifier")]
        public string LocationNumberQualifier { get; set; }
    }

    public class RequestOrderLineDTO
    {
        [JsonProperty("skuCode")]
        public string SkuCode { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class RequestSalesOrderDTO
    {
        [JsonProperty("salesOrderRef")]
        public string SalesOrderRef { get; set; }

        [JsonProperty("orderDate")]
        public string OrderDate { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("shipDate")]
        public string ShipDate { get; set; }

        [JsonProperty("categoryCode")]
        public string CategoryCode { get; set; }

        [JsonProperty("addresses")]
        public List<RequestAddressDTO> Addresses { get; set; }

        [JsonProperty("orderLines")]
        public List<RequestOrderLineDTO> OrderLines { get; set; }
    }

    public class JASSalesOrderRequestDTO
    {
        [JsonProperty("SalesOrder")]
        public RequestSalesOrderDTO SalesOrder { get; set; }

        public JASSalesOrderRequestDTO()
        {
            SalesOrder = new RequestSalesOrderDTO()
            {
                Addresses = new List<RequestAddressDTO>(),
                OrderLines = new List<RequestOrderLineDTO>()
            };
        }
    }

    public class JASSalesOrderRequestRootDTO
    {
        [JsonProperty("SalesOrderRequest")]
        public JASSalesOrderRequestDTO SalesOrderRequest { get; set; }

        public JASSalesOrderRequestRootDTO()
        {
            SalesOrderRequest = new JASSalesOrderRequestDTO()
            {
                SalesOrder = new RequestSalesOrderDTO()
            };
        }
    }
}