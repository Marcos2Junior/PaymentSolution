using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PaymentSolution.Application.Services.AuthenticationServices.GerenciaNet;
using PaymentSolution.Application.Services.HttpRequestServices.GerenciaNet;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace PaymentSolution.Application.IoC.PaymentServices
{
    public static class GerenciaNetServiceExtensions
    {
        public static IServiceCollection AddGerenciaNet(this IServiceCollection services)
        {
            services.AddScoped<GerenciaNetAuthentication>();
            services.AddScoped<GerenciaNetHttpService>();
            Uri baseAddress = new Uri("https://api-pix-h.gerencianet.com.br");
            services.AddHttpClient<GerenciaNetAuthentication>(client =>
            {
                client.BaseAddress = baseAddress;
            });

            services.AddHttpClient<GerenciaNetHttpService>(client =>
            {
                client.BaseAddress = baseAddress;
            }).ConfigurePrimaryHttpMessageHandler((sp) =>
            {
                var handler = new HttpClientHandler()
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12
                };

                var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
                if (httpContextAccessor?.HttpContext != null && httpContextAccessor.HttpContext.User.Identity is ClaimsIdentity identity)
                {
                    var gerenciaNetClaim = identity.FindFirst("gerencianet");

                    if (gerenciaNetClaim != null)
                    {
                        FileInfo fileCertificate = new($"Resources/Certificates/{gerenciaNetClaim.Value}/certificate.p12");
                        handler.ClientCertificates.Add(new X509Certificate2(fileCertificate.FullName, ""));
                    }

                }
                return handler;
            });

            return services;
        }
    }
}
