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
    public class InsertAnimalProductionUseCase : IInsertAnimalProductionUseCase
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

        public async Task<ApplicationResponse> HandleAsync(InsertAnimalProductionRequest data)
        {
            var response = ApplicationResponse.OfNone();

            var housing = await _housingRepository.GetByIdAsync(data.HousingId);

            if (housing == null)
                return response.BadRequest().WithError(ApplicationError.WasNullForArgument("Housing", nameof(data.HousingId)));

            var animalProduction = new AnimalProduction
            {
                Housing = housing,
                Birthday = data.BirthDay,
                Equipament = data.Equipament,
                MonitoringStart = data.MonitoringStart,
                MonitoringEnd = data.MonitoringEnd
            };

            var species = await _speciesRepository.GetByIdAsync(data.SpeciesId);
            if (species != default)
                animalProduction.Species = species;

            await _animalProductionRepository.InsertAsync(animalProduction);
            await _unitOfWork.SaveChangesAsync();

            return response.WithCode(HttpStatusCode.Created).WithData(new { AnimalProductionId = animalProduction.Id });
        }
    }
}
