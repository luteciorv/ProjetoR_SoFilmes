using FluentValidation;
using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoFilmes.Application.Movies.Commands.Handlers
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidator<UpdateMovieCommand> _validator;

        public UpdateMovieCommandHandler(IUnitOfWork uow, IValidator<UpdateMovieCommand> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public async Task Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
        {
            var result = _validator.Validate(command);
            if (!result.IsValid) throw new ValidationRequestException($"Não foi possível atualizar os dados do filme de id {command.Id}", result.Errors);

            var movie = await _uow.Movies.GetByIdAsync(command.Id) ?? 
                        throw new EntityNotFoundException($"O filme de id {command.Id} não foi encontrado.");

            movie.Update(command.Title, command.Summary, command.DurationInMinutes, command.AgeClassification);

            _uow.Movies.Update(movie);
            await _uow.CommitAsync();
        }
    }
}
