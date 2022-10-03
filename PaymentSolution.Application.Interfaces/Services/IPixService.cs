using PaymentSolution.Shared.Dtos.Default;
using PaymentSolution.Shared.Dtos.Pix;

namespace PaymentSolution.Application.Interfaces.Services
{
    public interface IPixService
    {
        Task<PaymentSolutionResponse<PIxDetailsDto>> CreateAsync(CreatePixDto createPixDto);
        Task<PaymentSolutionResponse<PIxDetailsDto>> GetAsync(string id, bool includeQrCode = false, int height = 186, int width = 168);
        Task<PaymentSolutionResponse<PixFullDto>> GetFullAsync(string endToEndId);
    }
}
