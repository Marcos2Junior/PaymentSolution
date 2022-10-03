using AutoMapper;
using PaymentSolution.Application.Interfaces.Services;
using PaymentSolution.Infrastructure.Interfaces.Repositories;
using PaymentSolution.Shared.Dtos.Default;
using PaymentSolution.Shared.Dtos.PaymentService;
using PaymentSolution.Shared.Enums;

namespace PaymentSolution.Application.Services
{
    public class PaymentServiceService : IPaymentServiceService
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IPaymentServiceRepository _paymentServiceRepository;

        public PaymentServiceService(IPaymentServiceRepository paymentServiceRepository, IAuthenticationService authenticationService, IMapper mapper)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
            _paymentServiceRepository = paymentServiceRepository;
        }
        public Task<PaymentSolutionResponse<PaymentServiceDto>> CreateAsync(CreatePaymentServiceDto createPaymentServiceDto)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentSolutionResponse<PaymentServiceDto>> GetPaymentServiceAsync(PaymentServiceType paymentServiceType, int userId = 0)
        {
            if (userId == 0)
            {
                userId = _authenticationService.UserClaimAuthentication().UserID;
            }

            var paymentService = await _paymentServiceRepository.GetPaymentServiceAsync(userId, paymentServiceType);
            if (paymentService == null)
            {
                return new PaymentSolutionResponse<PaymentServiceDto>($"service to {paymentServiceType} not found");
            }

            return new PaymentSolutionResponse<PaymentServiceDto>(_mapper.Map<PaymentServiceDto>(paymentService));
        }
    }
}
