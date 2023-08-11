using Microsoft.AspNetCore.Mvc.Filters;
using SoFilmes.Application.Exceptions;
using SoFilmes.WebApi.Exceptions.Handlers;

namespace SoFilmes.WebApi.Exceptions
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> _logger;
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;

            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationRequestException), HandlerValidationRequestException.Validation },
                { typeof(EntityNotFoundException), HandlerEntityException.NotFound }
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            _logger.LogWarning($"Uma exceção foi gerada. \nExceção: {context.Exception.Message}");

            var type = context.Exception.GetType();
            if(_exceptionHandlers.ContainsKey(type))
            {
                _logger.LogDebug("> Exceção mapeada - Realizando o seu tratamento...");
                _exceptionHandlers[type].Invoke(context);
                _logger.LogDebug("> Exceção tratada com sucesso.");
            }
            else
            {
                _logger.LogError(">> Exceção não mapeada.", context.Exception);
                HandlerUnknownException.Handler(context);
            }
        }
    }
}
