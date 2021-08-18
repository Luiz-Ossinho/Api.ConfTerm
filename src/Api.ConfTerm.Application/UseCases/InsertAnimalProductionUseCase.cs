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
        private readonly IUnitOfWork _unitOfWork;
        public InsertAnimalProductionUseCase(IRepository<AnimalProduction> animalProductionRepository, IUnitOfWork unitOfWork, IRepository<Housing> housingRepository)
        {
            _unitOfWork = unitOfWork;
            _animalProductionRepository = animalProductionRepository;
            _housingRepository = housingRepository;
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

            await _animalProductionRepository.InsertAsync(animalProduction);
            await _unitOfWork.SaveChangesAsync();

            return response.WithCode(HttpStatusCode.Created).WithData(new { AnimalProductionId = animalProduction.Id });
        }
    }
}
