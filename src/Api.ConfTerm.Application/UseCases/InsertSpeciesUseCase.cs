using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using System.Net;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class InsertSpeciesUseCase : IInsertSpeciesUseCase
    {
        private readonly IRepository<Species> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public InsertSpeciesUseCase(IRepository<Species> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse> HandleAsync(InsertSpeciesRequest data)
        {
            var response = ApplicationResponse.OfNone();

            if (string.IsNullOrWhiteSpace(data.Name))
                return response.BadRequest().WithError(ApplicationError.ArgumentWasInvalid(nameof(data.Name)));

            var species = new Species
            {
                Name = data.Name
            };

            await _repository.InsertAsync(species);
            await _unitOfWork.SaveChangesAsync();

            return response.WithCode(HttpStatusCode.Created).WithData(new { SpeciesId = species.Id });
        }
    }
}
