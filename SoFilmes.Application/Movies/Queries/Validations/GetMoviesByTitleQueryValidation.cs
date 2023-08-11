using FluentValidation;

namespace SoFilmes.Application.Movies.Queries.Validations
{
    public class GetMoviesByTitleQueryValidation : AbstractValidator<GetMoviesByTitleQuery>
    {
        public GetMoviesByTitleQueryValidation()
        {
            RuleFor(m => m.Skip).GreaterThanOrEqualTo(0).WithMessage("Não é possível ignorar uma quantidade negativa de filmes.");

            RuleFor(m => m.Take).GreaterThan(0).WithMessage("Não é possível recuperar uma quantidade negativa ou zero de filmes.");
            RuleFor(m => m.Take).LessThanOrEqualTo(100).WithMessage("Não é possível recuperar mais de 100 filmes.");
        }
    }
}
