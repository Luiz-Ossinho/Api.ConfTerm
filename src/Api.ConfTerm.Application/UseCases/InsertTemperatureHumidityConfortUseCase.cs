using Api.ConfTerm.Application.Abstract;
using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class InsertTemperatureHumidityConfortUseCase : IUseCase<InsertTemperatureHumidityConfortRequest>
    {
        private readonly IRepository<TemperatureHumidityConfort> _thRepository;
        private readonly IRepository<Species> _speciesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertTemperatureHumidityConfortUseCase(IRepository<TemperatureHumidityConfort> thRepository, IUnitOfWork unitOfWork, IRepository<Species> speciesRepository)
        {
            _thRepository = thRepository;
            _unitOfWork = unitOfWork;
            _speciesRepository = speciesRepository;
        }

        public async Task<ApplicationResponse> Handle(InsertTemperatureHumidityConfortRequest request, CancellationToken cancellationToken = default)
        {
            var response = ApplicationResponse.OfNone();

            // TODO aplicar validacoes
            //response.CheckFor()
            //

            var species = await _speciesRepository.GetByIdAsync(request.SpeciesId, cancellationToken);

            if (species == null)
                return response.BadRequest().WithError(ApplicationError.WasNullForArgument("User", nameof(request.SpeciesId)));

            await PersistTemperatureHumidityConfort(request, species, cancellationToken);

            return response.WithCode(HttpStatusCode.Created);
        }

        private async Task PersistTemperatureHumidityConfort(InsertTemperatureHumidityConfortRequest data, Species species, CancellationToken cancellationToken = default)
        {
            var confort = new TemperatureHumidityConfort
            {
                Level = data.Level,
                MaximunAge = data.MaximunAge,
                MinimunAge = data.MinimunAge,
                Species = species,
                MaximunHumidity = data.MaximunHumidity,
                MinimunHumidity = data.MinimunHumidity,
                MaximunTemperature = data.MaximunTemperature,
                MinimunTemperature = data.MinimunTemperature
            };
            await _thRepository.InsertAsync(confort, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
