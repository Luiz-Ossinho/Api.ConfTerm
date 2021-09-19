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
    public class InsertAnimalProductionUseCase : IUseCase<InsertAnimalProductionRequest>
    {
        private readonly IRepository<AnimalProduction> _animalProductionRepository;
        private readonly IRepository<Housing> _housingRepository;
        private readonly IRepository<Species> _speciesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InsertAnimalProductionUseCase(IRepository<AnimalProduction> animalProductionRepository, IUnitOfWork unitOfWork, IRepository<Housing> housingRepository,
            IRepository<Species> speciesRepository)
        {
            _unitOfWork = unitOfWork;
            _animalProductionRepository = animalProductionRepository;
            _housingRepository = housingRepository;
            _speciesRepository = speciesRepository;
        }

        public async Task<ApplicationResponse> Handle(InsertAnimalProductionRequest request, CancellationToken cancellationToken = default)
        {
            var response = ApplicationResponse.OfNone();

            var housing = await _housingRepository.GetByIdAsync(request.HousingId, cancellationToken);

            if (housing == null)
                return response.BadRequest().WithError(ApplicationError.WasNullForArgument("Housing", nameof(request.HousingId)));

            int animalProductionId = await PersistAnimalProduction(request, housing, cancellationToken);

            return response.WithCode(HttpStatusCode.Created).WithData(new { AnimalProductionId = animalProductionId });
        }

        private async Task<int> PersistAnimalProduction(InsertAnimalProductionRequest request, Housing housing, CancellationToken cancellationToken)
        {
            var animalProduction = new AnimalProduction
            {
                Housing = housing,
                Birthday = request.BirthDay,
                Equipament = request.Equipament,
                MonitoringStart = request.MonitoringStart,
                MonitoringEnd = request.MonitoringEnd
            };

            var species = await _speciesRepository.GetByIdAsync(request.SpeciesId, cancellationToken);
            if (species != default)
                animalProduction.Species = species;

            await _animalProductionRepository.InsertAsync(animalProduction, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var animalProductionId = animalProduction.Id;
            return animalProductionId;
        }
    }
}
