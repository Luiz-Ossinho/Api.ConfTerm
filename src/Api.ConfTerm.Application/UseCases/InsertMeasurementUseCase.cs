using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class InsertMeasurementUseCase : IUseCase<InsertMeasurementRequest>
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

        public async Task<ApplicationResponse> Handle(InsertMeasurementRequest request, CancellationToken cancelletionToken = default)
        {
            var response = ApplicationResponse.OfOk();

            var animalProduction = await _animalProductionRepository.GetByIdAsync(request.AnimalProductionId, cancelletionToken);

            if (animalProduction == default)
                return response.WithNotFound(ApplicationError.OfNotFound(nameof(animalProduction)));

            await PersistMeasurement(request, animalProduction, cancelletionToken);

            return response.WithCreated();
        }

        private async Task PersistMeasurement(InsertMeasurementRequest request, AnimalProduction animalProduction, CancellationToken cancelletionToken)
        {
            var measurement = request.ToMeasurement();
            measurement.Production = animalProduction;
            await _measurementRepository.InsertAsync(measurement, cancelletionToken);
            await _unitOfWork.SaveChangesAsync(cancelletionToken);
        }
    }
}
