using Microsoft.Extensions.DependencyInjection;
using PaymentSolution.Application.Interfaces.Services;
using PaymentSolution.Application.Services;

namespace PaymentSolution.Application.IoC
{
    public static class PaymentSolutionApplicationExtension
    {
        public static IServiceCollection AddPaymentSolutionServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAccessService, UserAccessService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
