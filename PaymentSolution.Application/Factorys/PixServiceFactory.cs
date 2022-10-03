using Microsoft.Extensions.DependencyInjection;
using PaymentSolution.Application.Interfaces.Services;
using PaymentSolution.Application.Services.Payments.Pix;
using PaymentSolution.Shared.Enums;

namespace PaymentSolution.Application.Factorys
{
    public class PixServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public PixServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPixService Create(PaymentServiceType serviceType)
        {
            return serviceType switch
            {
                PaymentServiceType.GerenciaNet => _serviceProvider.GetService<GerenciaNetPixService>(),
                PaymentServiceType.BancoBrasil => throw new NotImplementedException(),
                PaymentServiceType.Santander => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
