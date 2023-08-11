using FluentValidation.Results;

namespace SoFilmes.Application.Exceptions
{
    public sealed class ValidationRequestException : ExceptionBase
    {
        public ValidationRequestException(string message, List<ValidationFailure> errors) : base(message)
        {
            Errors = errors;
        }

        public IReadOnlyCollection<ValidationFailure> Errors;
    }
}
