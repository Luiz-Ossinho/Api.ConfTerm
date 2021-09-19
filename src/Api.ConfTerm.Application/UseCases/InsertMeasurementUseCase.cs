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
    public class InsertMeasurementUseCase : IUseCase<MeasurementRequest>
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

        public async Task<ApplicationResponse> Handle(MeasurementRequest request, CancellationToken cancelletionToken = default)
        {
            var response = ApplicationResponse.OfNone();

            var animalProduction = await _animalProductionRepository.GetByIdAsync(request.AnimalProductionId, cancelletionToken);

            response.CheckFor(animalProduction != null, ApplicationError.WasNullForArgument("Animal Production", "Animal Production Id"));

            if (!response.Success)
                return response;

            await PersistMeasurement(request, animalProduction, cancelletionToken);

            return response.WithCode(HttpStatusCode.Created);
        }

        private async Task PersistMeasurement(MeasurementRequest request, AnimalProduction animalProduction, CancellationToken cancelletionToken)
        {
            var measurement = request.ToMeasurement();
            measurement.Production = animalProduction;
            await _measurementRepository.InsertAsync(measurement, cancelletionToken);
            await _unitOfWork.SaveChangesAsync(cancelletionToken);
        }
    }
}
