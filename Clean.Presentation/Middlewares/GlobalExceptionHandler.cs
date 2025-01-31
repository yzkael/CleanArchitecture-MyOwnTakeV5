using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Application.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Presentation.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {

        private readonly ILoggerServices _logger;

        public GlobalExceptionHandler(ILoggerServices logger)
        {
            _logger = logger;
        }



        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError($"{exception}, Exception ocurred: {exception.Message}");

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Server error"
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}