using Microsoft.AspNetCore.Http;
using SalesOrder.Shared.DTOs;

namespace SalesOrder.Service.Interfaces
{
    public interface ISalesOrderService
    {
        public Task<ValidateDeserilalizeResultDTO> ValidateSalesOrderFile(IFormFile salesOrder);

        public Task<ValidateDeserilalizeResultDTO> DeseriliazeSalesOrder(IFormFile salesOrder);

        public Task<List<MessageDTO>> ValidateSalesOrder(SalesOrderRequestDTO salesOrder);

        public Task<bool> ProcessSalesOrder(SalesOrderRequestDTO salesOrder);
    }
}