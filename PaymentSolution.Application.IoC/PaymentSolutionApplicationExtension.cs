using Microsoft.Extensions.DependencyInjection;
using PaymentSolution.Application.Factorys;
using PaymentSolution.Application.Interfaces.Services;
using PaymentSolution.Application.IoC.PaymentServices;
using PaymentSolution.Application.Services;
using PaymentSolution.Application.Services.Payments.Pix;

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
            services.AddScoped<IPaymentServiceService, PaymentServiceService>();

            /*
             * declare services to pix
             */
            services
                .AddScoped<PixServiceFactory>()
                .AddScoped<GerenciaNetPixService>();

            services.AddGerenciaNet();

            return services;
        }
    }
}
