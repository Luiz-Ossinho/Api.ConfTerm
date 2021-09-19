using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class InsertSpeciesUseCase : IUseCase<InsertSpeciesRequest>
    {
        private readonly IRepository<Species> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public InsertSpeciesUseCase(IRepository<Species> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicationResponse> Handle(InsertSpeciesRequest request, CancellationToken cancelletionToken = default)
        {
            var response = ApplicationResponse.OfNone();

            if (string.IsNullOrWhiteSpace(request.Name))
                return response.BadRequest().WithError(ApplicationError.ArgumentWasInvalid(nameof(request.Name)));

            var speciesId = await PersistSpecies(request, cancelletionToken);

            return response.WithCode(HttpStatusCode.Created).WithData(new { SpeciesId = speciesId });
        }

        private async Task<int> PersistSpecies(InsertSpeciesRequest request, CancellationToken cancelletionToken)
        {
            var species = new Species
            {
                Name = request.Name
            };

            await _repository.InsertAsync(species, cancelletionToken);
            await _unitOfWork.SaveChangesAsync(cancelletionToken);

            return species.Id;
        }
    }
}
