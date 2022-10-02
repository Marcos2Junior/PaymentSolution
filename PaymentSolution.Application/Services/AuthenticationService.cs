using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using PaymentSolution.Application.Helpers;
using PaymentSolution.Application.Interfaces.Models;
using PaymentSolution.Application.Interfaces.Services;
using PaymentSolution.Shared.Dtos.Authentication;
using PaymentSolution.Shared.Dtos.Default;
using PaymentSolution.Shared.Dtos.UserAccess;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaymentSolution.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserAccessService _userAccessService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string SecretKey = "5fd924625f6ab16a19cc9807c7c506ae1813490e4ba675f843d5a10e0baacdb8";

        public AuthenticationService(IUserService userService, IHttpContextAccessor httpContextAccessor, IUserAccessService userAccessService)
        {
            _userAccessService = userAccessService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<PaymentSolutionResponse<AuthenticationCreatedDto>> CreateAuthenticationAsync(CreateAuthenticationDto createAuthenticationDto)
        {
            var userResponse = await _userService.GetUserWithPasswordByEmailAsync(createAuthenticationDto?.Email);
            if (!userResponse.Success)
            {
                return new PaymentSolutionResponse<AuthenticationCreatedDto>(userResponse.Message);
            }

            if (userResponse.Model.Password == createAuthenticationDto.Password.ToSHA512())
            {
                var userAccess = await _userAccessService.NewAccessAsync(userResponse.Model);
                return new PaymentSolutionResponse<AuthenticationCreatedDto>(GenerateToken(userAccess, new Dictionary<string, string>()));
            }

            return new PaymentSolutionResponse<AuthenticationCreatedDto>("Email ou senha inválida");
        }

        public ClaimsPrincipal? GetClaimsPrincipal(string token, bool validateLifeTime)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
                    ValidateLifetime = validateLifeTime
                }, out SecurityToken securityToken);

                if (securityToken is JwtSecurityToken jwtSecurityToken && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase))
                {
                    return principal;
                }
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<PaymentSolutionResponse<AuthenticationCreatedDto>> RefreshTokenAsync(string token, string refreshToken)
        {
            var claimPrincipal = GetClaimsPrincipal(token, false);

            if (claimPrincipal != null)
            {
                var userAccessUpdated = await _userAccessService.UpdateAccessAsync(int.Parse(claimPrincipal.FindFirst("userAccessId").Value), refreshToken);
                if (userAccessUpdated != null)
                {
                    return new PaymentSolutionResponse<AuthenticationCreatedDto>(GenerateToken(userAccessUpdated, new Dictionary<string, string>()));
                }
            }

            return new PaymentSolutionResponse<AuthenticationCreatedDto>();
        }

        public UserClaimAuthentication UserClaimAuthentication()
        {
            if (_httpContextAccessor.HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
                if (claim != null)
                {
                    return new UserClaimAuthentication
                    {
                        UserID = int.Parse(claim.Value),
                        ServiceIdGerenciaNet = identity.FindFirst("gerencianet")?.Value
                    };
                }
            }

            return null;
        }

        private AuthenticationCreatedDto GenerateToken(UserAccessDto userAccess, IDictionary<string, string> aditionalClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(SecretKey));

            List<Claim> claims = new(aditionalClaims.Select(x => new Claim(x.Key, x.Value)))
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userAccess.UserID.ToString()),
                new Claim("userAccessId", userAccess.ID.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512)
            };

            return new AuthenticationCreatedDto
            {
                Created = userAccess.DateTime,
                Expiration = tokenDescriptor.Expires.Value,
                RefreshToken = userAccess.RefreshToken,
                Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
            };
        }
    }
}
