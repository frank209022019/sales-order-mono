using Microsoft.AspNetCore.Http;
using SalesOrder.Shared.DTOs.JAS;

namespace SalesOrder.Service.Interfaces
{
    public interface IJASSalesService
    {
        Task<ValidateDeserilializeResultDTO?> ValidateDeserilializeRequest(IFormFile file);

        Task<GenerateSalesOrderResultDTO?> GenerateExpectedSalesOrder(JASSalesOrderRequestDTO request);
    }
}