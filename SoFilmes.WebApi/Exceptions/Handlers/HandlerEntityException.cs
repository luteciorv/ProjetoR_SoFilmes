using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SoFilmes.Application.Exceptions;

namespace SoFilmes.WebApi.Exceptions.Handlers
{
    public static class HandlerEntityException
    {
        public static void NotFound(ExceptionContext context)
        {
            if (context.Exception is not EntityNotFoundException exception) return;

            var details = new ProblemDetails
            {
                Title = exception.Message,
                Status = StatusCodes.Status404NotFound,
                Type = "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/404",
            };

            context.Result = new NotFoundObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}