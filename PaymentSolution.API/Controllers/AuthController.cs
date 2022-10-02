using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentSolution.Application.Interfaces.Services;
using PaymentSolution.Shared.Dtos.Authentication;

namespace PaymentSolution.API.Controllers
{
    [Route("api/auth"), ApiController, AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateAuthenticationDto createDto)
        {
            var authResponse = await _authenticationService.CreateAuthenticationAsync(createDto);
            return authResponse.Success ? StatusCode(201, authResponse) : StatusCode(401, authResponse);
        }

        [HttpPost("refresh-token/{token}/{refreshToken}")]
        public async Task<IActionResult> RefreshToken([FromRoute] string token, [FromRoute] string refreshToken)
        {
            var authResponse = await _authenticationService.RefreshTokenAsync(token, refreshToken);
            return authResponse.Success ? StatusCode(201, authResponse) : StatusCode(401, authResponse);
        }
    }
}
