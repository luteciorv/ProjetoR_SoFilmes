using FluentValidation;

namespace SoFilmes.Application.Genres.Queries.Validations
{
    public class GetGenresQueryValidation : AbstractValidator<GetGenresQuery>
    {
        public GetGenresQueryValidation()
        {
            RuleFor(m => m.Skip).GreaterThanOrEqualTo(0).WithMessage("Não é possível ignorar uma quantidade negativa de gêneros.");

            RuleFor(m => m.Take).GreaterThan(0).WithMessage("Não é possível recuperar uma quantidade negativa ou zero de gêneros.");
            RuleFor(m => m.Take).LessThanOrEqualTo(100).WithMessage("Não é possível recuperar mais de 100 gêneros.");
        }
    }
}
