using FluentValidation;

namespace SoFilmes.Application.Movies.Commands.Validations
{
    public class PatchMovieCommandValidation : AbstractValidator<PatchMovieCommand>
    {
        public PatchMovieCommandValidation()
        {
            RuleFor(m => m.Rating)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor da nota do filme precisa estar entre 0 e 5")

                .LessThanOrEqualTo(5)
                .WithMessage("O valor da nota do filme precisa estar entre 0 e 5");
        }
    }
}
