using PaymentSolution.Application.Interfaces.Services;
using PaymentSolution.Application.Services.HttpRequestServices.GerenciaNet;
using PaymentSolution.Infrastructure.Interfaces.Repositories;
using PaymentSolution.Shared.Dtos.Default;
using PaymentSolution.Shared.Dtos.Pix;

namespace PaymentSolution.Application.Services.Payments.Pix
{
    public class GerenciaNetPixService : IPixService
    {
        private readonly GerenciaNetHttpService _gerenciaNetHttpService;
        private readonly IPaymentRepository _paymentRepository;

        public GerenciaNetPixService(IPaymentRepository paymentRepository, GerenciaNetHttpService gerenciaNetHttpService)
        {
            _gerenciaNetHttpService = gerenciaNetHttpService;
            _paymentRepository = paymentRepository;
        }
        public async Task<PaymentSolutionResponse<PIxDetailsDto>> CreateAsync(CreatePixDto createPixDto)
        {
            var resp = await _gerenciaNetHttpService.NewRequestAsync("v2/cob", HttpMethod.Post, string.Empty, new
            {
                calendario = new
                {
                    expiracao = createPixDto.ExpirationInSeconds <= 0 ? 3600 : createPixDto.ExpirationInSeconds
                },
                devedor = new
                {
                    cpf = createPixDto.CustomerDetails.Document,
                    nome = createPixDto.CustomerDetails.Name
                },
                valor = new
                {
                    original = createPixDto.Amount.ToString().Replace(",", ".")
                },
                chave = createPixDto.Key,
                solicitacaoPagador = createPixDto.Message
            });

            if (resp.IsSuccessStatusCode)
            {
            }

            return null;
        }

        public Task<PaymentSolutionResponse<PIxDetailsDto>> GetAsync(string id, bool includeQrCode = false, int height = 186, int width = 168)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentSolutionResponse<PixFullDto>> GetFullAsync(string endToEndId)
        {
            throw new NotImplementedException();
        }
    }
}
