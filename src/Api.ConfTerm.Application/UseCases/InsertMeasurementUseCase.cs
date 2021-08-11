using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using System.Net;

namespace Api.ConfTerm.Application.UseCases
{
    public class InsertMeasurementUseCase : IInsertMeasurementUseCase
    {
        private readonly IRepository<Measurement> _measurementRepository;
        private readonly IRepository<AnimalProduction> _animalProductionRepository;
        public InsertMeasurementUseCase(IRepository<Measurement> measurementRepository, IRepository<AnimalProduction> animalProductionRepository)
        {
            _animalProductionRepository = animalProductionRepository;
            _measurementRepository = measurementRepository;
        }
        public ApplicationResponse Handle(MeasurementRequest data)
        {
            var animalProduction = _animalProductionRepository.GetById(data.AnimalProductionId);

            if (animalProduction == null)
                return ApplicationResponse.OfBadRequest()
                    .WithError(ApplicationError.WasNullForArgument("Animal Production","Animal Production Id"));

            var measurement = data.ToMeasurement();
            measurement.AnimalProduction = animalProduction;
            _measurementRepository.Insert(measurement);

            return ApplicationResponse.OfNone().WithCode(HttpStatusCode.Created);
        }
    }
}
