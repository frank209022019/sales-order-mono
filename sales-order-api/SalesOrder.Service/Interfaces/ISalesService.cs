using Microsoft.AspNetCore.Http;
using SalesOrder.Shared.DTOs;

namespace SalesOrder.Service.Interfaces
{
    public interface ISalesOrderService
    {
        public Task<SalesOrderResultDTO> ValidateSalesOrderFile(IFormFile salesOrder);

        public Task<SalesOrderResultDTO> DeseriliazeSalesOrder(IFormFile salesOrder);

        public Task<List<MessageDTO>> ValidateSalesOrder(SalesOrderRequestDTO salesOrder);

        public Task<SalesOrderResultDTO> ProcessSalesOrder(SalesOrderRequestDTO salesOrder);
    }
}