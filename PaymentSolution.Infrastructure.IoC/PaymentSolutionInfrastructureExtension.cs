using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentSolution.Infrastructure.Interfaces.Repositories;
using PaymentSolution.Infrastructure.Repositories;

namespace PaymentSolution.Infrastructure.IoC
{
    public static class PaymentSolutionInfrastructureExtension
    {
        public static IServiceCollection AddPaymentSolutionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentSolutionDataContext>(options => options.OnConfiguring(configuration));
            services.AddScoped(typeof(IPaymentSolutionRepository<>), typeof(PaymentSolutionRepository<>));

            return services;
        }
    }
}