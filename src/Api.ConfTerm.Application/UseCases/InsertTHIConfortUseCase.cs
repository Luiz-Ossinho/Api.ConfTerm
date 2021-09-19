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
    public class InsertTHIConfortUseCase : IUseCase<InsertTemperatureHumidityIndexConfortRequest>
    {
        private readonly IRepository<TemperatureHumidityIndexConfort> _thiRepository;
        private readonly IRepository<Species> _speciesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertTHIConfortUseCase(IRepository<TemperatureHumidityIndexConfort> thiRepository, IUnitOfWork unitOfWork, IRepository<Species> speciesRepository)
        {
            _thiRepository = thiRepository;
            _unitOfWork = unitOfWork;
            _speciesRepository = speciesRepository;
        }

        public async Task<ApplicationResponse> Handle(InsertTemperatureHumidityIndexConfortRequest request, CancellationToken cancellationToken = default)
        {
            var response = ApplicationResponse.OfOk();

            var species = await _speciesRepository.GetByIdAsync(request.SpeciesId, cancellationToken);

            if (species == default)
                return response.WithNotFound(ApplicationError.OfNotFound(nameof(species)));

            await PersistTemperatureHumidityIndexConfort(request, species, cancellationToken);

            return response.WithCreated();
        }

        private async Task PersistTemperatureHumidityIndexConfort(InsertTemperatureHumidityIndexConfortRequest request, Species species, CancellationToken cancellationToken = default)
        {
            var confort = new TemperatureHumidityIndexConfort
            {
                Level = request.Level,
                MaximunAge = request.MaximunAge,
                MinimunAge = request.MinimunAge,
                MaximunTemperatureHumidityIndex = request.MaximunTHI,
                MinimunTemperatureHumidityIndex = request.MinimunTHI,
                Species = species
            };

            await _thiRepository.InsertAsync(confort, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
