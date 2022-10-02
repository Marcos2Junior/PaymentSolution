using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PaymentSolution.Shared.Dtos.Default;
using System.Collections;

namespace PaymentSolution.API.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        private readonly IWebHostEnvironment _environment;

        public HttpResponseExceptionFilter(IWebHostEnvironment webHostEnvironment)
        {
            _environment = webHostEnvironment;
        }
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var objectResult = context.Result as ObjectResult;

            if (objectResult?.Value is not PaymentSolutionVoidResponse)
            {
                context.ExceptionHandled = context.Exception != null;
                string message = string.Empty;

                if (_environment.IsDevelopment())
                {
                    message = "default response is not implemented";
                    if (context.Exception != null)
                    {
                        context.Result = new JsonResult(new PaymentSolutionResponse<ExceptionResult>(new ExceptionResult(context.Exception), message, false))
                        {
                            StatusCode = StatusCodes.Status500InternalServerError
                        };

                        return;
                    }
                }

                context.Result = new JsonResult(new PaymentSolutionVoidResponse(false, message))
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        class ExceptionResult
        {
            public string Message { get; private set; }
            public string? Source { get; private set; }
            public string? StackTrace { get; private set; }
            public ExceptionResult InnerException { get; private set; }
            public Dictionary<string, string> Data { get; private set; } = new Dictionary<string, string>();
            public ExceptionResult(Exception exception)
            {
                Message = exception.Message;
                StackTrace = exception?.StackTrace;
                Source = exception?.Source;
                if (exception.InnerException != null)
                {
                    InnerException = new ExceptionResult(exception.InnerException);
                }
                if (exception.Data != null)
                {
                    foreach (DictionaryEntry data in exception.Data)
                    {
                        string key = Convert.ToString(data.Key);
                        if (string.IsNullOrEmpty(key))
                        {
                            Data.Add(key, data.Value.ToString());
                        }
                    }
                }
            }
        }
    }
}
