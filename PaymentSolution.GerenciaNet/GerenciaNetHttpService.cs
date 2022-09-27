using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSolution.GerenciaNet
{
    public class GerenciaNetHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GerenciaNetHttpService> _logger;
        private readonly GerenciaNetAuthentication _auth;

        public GerenciaNetHttpService(GerenciaNetAuthentication authentication, ILogger<GerenciaNetHttpService> logger, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _auth = authentication;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> NewRequestAsync(string resource, HttpMethod httpMethod, string query, object body)
        {
            int attempts = 0;
            do
            {
                var request = new HttpRequestMessage(httpMethod, FormatUrlSegment(resource, query));
                if (body != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                }
                await _auth.GetCredentialsAsync();

                request.Headers.Authorization = new AuthenticationHeaderValue(_auth.Token.Token_type, _auth.Token.Access_token);

                var response = await _httpClient.SendAsync(request);

                string sdf = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                Thread.Sleep(500);
                attempts++;
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await _auth.GetCredentialsAsync(true);
                }
            } while (attempts < 3);

            throw new Exception($"attempt limit {resource} {httpMethod} {query}");
        }

        private string FormatUrlSegment(string resource, string query)
        {
            string result = resource;
            if (!string.IsNullOrEmpty(query))
            {
                result += $"?{query}";
            }

            return result;
        }
    }
}
