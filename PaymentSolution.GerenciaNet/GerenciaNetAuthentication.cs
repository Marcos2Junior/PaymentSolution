using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace PaymentSolution.GerenciaNet
{
    public class GerenciaNetAuthentication
    {
        private readonly ILogger<GerenciaNetAuthentication> _logger;
        private readonly HttpClient _httpClient;
        public TokenDetails Token { get; private set; }
        public GerenciaNetAuthentication(ILogger<GerenciaNetAuthentication> logger, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task GetCredentialsAsync(bool force = false)
        {
            if (force || Token == null || DateTime.Now.AddSeconds(30) >= Token.Creation.AddSeconds(Token.Expires_in))
            {
                var response = await _httpClient.PostAsync("oauth/token",
                    new StringContent("{\"grant_type\": \"client_credentials\"}", Encoding.UTF8, "application/json"));

                string body = await response.Content?.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    Token = JsonConvert.DeserializeObject<TokenDetails>(body);
                }
                else
                {
                    _logger.LogError($"error authentication => {response.StatusCode} - {body}");
                }
            }
        }
    }

    public class TokenDetails
    {
        [JsonProperty("access_token")]
        public string Access_token { get; private set; }
        [JsonProperty("token_type")]
        public string Token_type { get; private set; }
        [JsonProperty("expires_in")]
        public int Expires_in { get; private set; }
        [JsonProperty("scope")]
        public string Scope { get; private set; }
        public DateTime Creation { get; private set; }
        public TokenDetails(string access_token, string token_type, int expires_in, string scope)
        {
            Access_token = access_token;
            Token_type = token_type;
            Expires_in = expires_in;
            Scope = scope;
            Creation = DateTime.Now;
        }
    }
}
