using Api.ConfTerm.Application.Objects;

namespace Api.ConfTerm.Application.Abstract.UseCases
{
    public interface IRemoveTemperatureHumidityConfortUseCase : IUseCase<MeasurementRequest, ApplicationResponse>
    {
    }
}
