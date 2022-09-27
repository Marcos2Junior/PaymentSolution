using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;

namespace PaymentSolution.GerenciaNet
{
    public static class GerenciaNetServiceCollectionExtensions
    {
        public static IServiceCollection AddGerenciaNet(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<GerenciaNetAuthentication>();
            services.AddScoped<GerenciaNetHttpService>();

            string clientID = configuration["GerenciaNet:ClientID"];
            string clientSecret = configuration["GerenciaNet:ClienteSecret"];
            string baseUrl = configuration["GerenciaNet:BaseUrl"];
            string certificate = configuration["GerenciaNet:Certificate"];
            FileInfo fileCertificate = new(certificate);
            if (!fileCertificate.Exists)
            {
                throw new FileNotFoundException("GerenciaNet certificate not found", fileCertificate.FullName);
            }
            if (string.IsNullOrEmpty(clientID) || string.IsNullOrEmpty(clientSecret) || string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(certificate))
            {
                throw new Exception("GerenciaNet credentials is null or empty");
            }

            services.AddHttpClient<GerenciaNetAuthentication>(client =>
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    $"{Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientID}:{clientSecret}"))}");
            }).ConfigureHttpClient(certificate, baseUrl);
            services.AddHttpClient<GerenciaNetHttpService>().ConfigureHttpClient(certificate, baseUrl);

            return services;
        }

        private static IHttpClientBuilder ConfigureHttpClient(this IHttpClientBuilder builder, string certificate, string baseUrl)
        {
            return builder.ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler()
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12
                };

                handler.ClientCertificates.Add(new X509Certificate2(certificate, ""));
                return handler;
            });
        }
    }
}
