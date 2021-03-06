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
    public class InsertMeasurementUseCase : IInsertMeasurementUseCase
    {
        private readonly IRepository<Measurement> _measurementRepository;
        private readonly IRepository<AnimalProduction> _animalProductionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InsertMeasurementUseCase(IRepository<Measurement> measurementRepository, IRepository<AnimalProduction> animalProductionRepository,
            IUnitOfWork unitOfWork)
        {
            _animalProductionRepository = animalProductionRepository;
            _measurementRepository = measurementRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse> HandleAsync(MeasurementRequest data)
        {
            var response = ApplicationResponse.OfNone();

            var animalProduction = await _animalProductionRepository.GetByIdAsync(data.AnimalProductionId);

            response.CheckFor(animalProduction != null, ApplicationError.WasNullForArgument("Animal Production", "Animal Production Id"));
            
            if (!response.Success)
                return response;

            var measurement = data.ToMeasurement();
            measurement.Production = animalProduction;
            await _measurementRepository.InsertAsync(measurement);
            await _unitOfWork.SaveChangesAsync();

            return response.WithCode(HttpStatusCode.Created);
        }
    }
}
