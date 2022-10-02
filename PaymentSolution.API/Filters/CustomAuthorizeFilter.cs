using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PaymentSolution.Shared.Dtos.Default;

namespace PaymentSolution.API.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAuthorizeFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            if (context.HttpContext.Items["User"] == null)
            {
                context.Result = new JsonResult(new PaymentSolutionVoidResponse(false, "unauthorized")) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
