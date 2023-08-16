using FluentValidation;
using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Domain.Enums;

namespace SoFilmes.Application.Movies.Commands.Validations
{
    public class CreateMovieCommandValidation : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidation(IUnitOfWork uow)
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage(m => $"O campo '{nameof(m.Title)}' do filme é obrigatório");
            RuleFor(m => m.Title.Length)
                .LessThanOrEqualTo(100)
                .WithMessage(m => $"O campo '{nameof(m.Title)}' do filme não pode ultrapassar 100 caracteres.");

            RuleFor(m => m.Summary)
                .NotEmpty()
                .WithMessage(m => $"O campo '{nameof(m.Summary)}' do filme é obrigatório");
            RuleFor(m => m.Summary.Length)
                .LessThanOrEqualTo(500)
                .WithMessage(m => $"O campo '{nameof(m.Summary)}' do filme não pode ultrapassar 500 caracteres.");

            RuleFor(m => m.DurationInMinutes)
                .GreaterThanOrEqualTo(30)
                .WithMessage(m => $"O campo '{nameof(m.DurationInMinutes)}' do filme precisa ter ao menos 30min de duração.");
            RuleFor(m => m.DurationInMinutes)
                .LessThanOrEqualTo(300)
                .WithMessage(m => $"O campo '{nameof(m.DurationInMinutes)}' do filme não pode ultrapassar 300min de duração.");

            RuleFor(m => m.AgeClassification)
                .Must(ageClass => Enum.IsDefined(typeof(EAgeClassification), ageClass))
                .WithMessage(m => $"O campo '{nameof(m.AgeClassification)}' não está correto. O valor informado não existe.");

            RuleFor(m => m.GenresId).Must(genresId =>
            {
                var genres = uow.Genres.GetAll().Select(g => g.Id);
                return genresId.All(id => genres.Contains(id));
            }).WithMessage(m => $"O campo '{nameof(m.GenresId)}' não está correto. Alguns gêneros não foram cadastrados.");
        }
    }
}
