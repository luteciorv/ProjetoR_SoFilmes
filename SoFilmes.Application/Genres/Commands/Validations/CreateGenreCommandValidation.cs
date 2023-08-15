using FluentValidation;

namespace SoFilmes.Application.Genres.Commands.Validations
{
    public class CreateGenreCommandValidation : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidation()
        {
            RuleFor(g => g.Name)
                .NotEmpty().WithMessage(g => $"O campo '{nameof(g.Name)}' não pode ser vazio.")
                .Length(1, 25).WithMessage(g => $"O campo '{nameof(g.Name)}' precisa conter de 1 a 25 caracteres.");
        }
    }
}
