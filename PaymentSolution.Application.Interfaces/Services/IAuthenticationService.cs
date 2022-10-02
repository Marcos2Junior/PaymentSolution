using PaymentSolution.Application.Interfaces.Models;
using PaymentSolution.Shared.Dtos.Authentication;
using PaymentSolution.Shared.Dtos.Default;
using System.Security.Claims;

namespace PaymentSolution.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<PaymentSolutionResponse<AuthenticationCreatedDto>> CreateAuthenticationAsync(CreateAuthenticationDto createAuthenticationDto);
        Task<PaymentSolutionResponse<AuthenticationCreatedDto>> RefreshTokenAsync(string token, string refreshToken);
        public ClaimsPrincipal? GetClaimsPrincipal(string token, bool validateLifeTime);
        UserClaimAuthentication UserClaimAuthentication();
    }
}
