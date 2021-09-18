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
    public class InsertBGTHIConfortUseCase : IUseCase<InsertBGTHIConfortRequest>
    {
        private readonly IRepository<BlackGlobeTemparuteHumidityIndexConfort> _bgthiRepository;
        private readonly IRepository<Species> _speciesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertBGTHIConfortUseCase(IRepository<BlackGlobeTemparuteHumidityIndexConfort> bgthiRepository,
            IUnitOfWork unitOfWork, IRepository<Species> speciesRepository)
        {
            _bgthiRepository = bgthiRepository;
            _unitOfWork = unitOfWork;
            _speciesRepository = speciesRepository;
        }

        public async Task<ApplicationResponse> Handle(InsertBGTHIConfortRequest request, CancellationToken cancellationToken = default)
        {
            var response = ApplicationResponse.OfNone();

            // TODO aplicar validacoes
            //response.CheckFor()
            //

            var species = await _speciesRepository.GetByIdAsync(request.SpeciesId, cancellationToken);

            if (species == null)
                return response.BadRequest().WithError(ApplicationError.WasNullForArgument("User", nameof(request.SpeciesId)));

            await PersistBlackGlobeTemperatureHumidityIndexConfort(request, species, cancellationToken);

            return response.WithCode(HttpStatusCode.Created);
        }

        private async Task PersistBlackGlobeTemperatureHumidityIndexConfort(InsertBGTHIConfortRequest request, Species species, CancellationToken cancellationToken)
        {
            var confort = new BlackGlobeTemparuteHumidityIndexConfort
            {
                Level = request.Level,
                MaximunAge = request.MaximunAge,
                MinimunAge = request.MinimunAge,
                Species = species,
                MaximunBlackGlobeTemperatureHumidityIndex = request.MaximunBGTHI,
                MinimunBlackGlobeTemperatureHumidityIndex = request.MinimunBGTHI
            };

            await _bgthiRepository.InsertAsync(confort, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
