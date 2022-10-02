using PaymentSolution.Application.Interfaces.Services;

namespace PaymentSolution.API.MIddlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthenticationService authenticationService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                var claimPrincipal = authenticationService.GetClaimsPrincipal(token, true);

                if (claimPrincipal == null)
                {
                    context.Request.Headers.Remove("Authorization");
                }
                else
                {
                    context.Items["User"] = claimPrincipal.Identity;
                }
            }

            await _next(context);
        }
    }
}
