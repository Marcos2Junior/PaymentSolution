using PaymentSolution.Shared.Dtos.Default;
using PaymentSolution.Shared.Dtos.PaymentService;
using PaymentSolution.Shared.Enums;

namespace PaymentSolution.Application.Interfaces.Services
{
    public interface IPaymentServiceService
    {
        Task<PaymentSolutionResponse<PaymentServiceDto>> CreateAsync(CreatePaymentServiceDto createPaymentServiceDto);
        Task<PaymentSolutionResponse<PaymentServiceDto>> GetPaymentServiceAsync(PaymentServiceType paymentServiceType, int userId = 0);
    }
}
