using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Requests;

namespace Api.ConfTerm.Application.Abstract.UseCases
{
    public interface IInsertMeasurementUseCase : IUseCase<MeasurementRequest, ApplicationResponse>
    {
    }
}
