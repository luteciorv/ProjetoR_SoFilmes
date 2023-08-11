using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SoFilmes.Application.Exceptions;

namespace SoFilmes.WebApi.Exceptions.Handlers
{
    public static class HandlerValidationRequestException
    {
        public static void Validation(ExceptionContext context)
        {
            if (context.Exception is not ValidationRequestException exception) return;

            var errorDetails = exception.Errors.Select(error => new
            {
                FieldName = error.PropertyName,
                Error = error.ErrorMessage,         
            });

            var details = new ProblemDetails
            {
                Title = exception.Message,
                Status = StatusCodes.Status400BadRequest,
                Type = "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/400",
            };

            details.Extensions.Add("Invalid Fields", errorDetails);

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}