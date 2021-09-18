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
    public class InsertTHIConfortUseCase : IUseCase<InsertTHIConfortRequest>
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

        public async Task<ApplicationResponse> Handle(InsertTHIConfortRequest request, CancellationToken cancellationToken = default)
        {
            var response = ApplicationResponse.OfNone();

            // TODO aplicar validacoes
            //response.CheckFor()
            //

            var species = await _speciesRepository.GetByIdAsync(request.SpeciesId, cancellationToken);

            if (species == null)
                return response.BadRequest().WithError(ApplicationError.WasNullForArgument("User", nameof(request.SpeciesId)));

            await PersistTemperatureHumidityIndexConfort(request, species, cancellationToken);

            return response.WithCode(HttpStatusCode.Created);
        }

        private async Task PersistTemperatureHumidityIndexConfort(InsertTHIConfortRequest request, Species species, CancellationToken cancellationToken = default)
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
