using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentSolution.Infrastructure.Interfaces.Repositories;
using PaymentSolution.Infrastructure.Repositories;
using PaymentSolution.Infrastructure.Seeding;

namespace PaymentSolution.Infrastructure.IoC
{
    public static class PaymentSolutionInfrastructureExtension
    {
        public static IServiceCollection AddPaymentSolutionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentSolutionDataContext>(options => options.OnConfiguring(configuration));
            services.AddScoped(typeof(IPaymentSolutionRepository<>), typeof(PaymentSolutionRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAccessRepository, UserAccessRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentServiceRepository, PaymentServiceRepository>();
            return services;
        }

        public static IApplicationBuilder UseItToSeed(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PaymentSolutionDataContext>();
            SeedingService.Seed(context);
            return app;
        }
    }
}