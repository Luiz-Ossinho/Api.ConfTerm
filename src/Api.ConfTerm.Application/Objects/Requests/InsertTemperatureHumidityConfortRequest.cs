using Api.ConfTerm.Application.Abstract;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertTemperatureHumidityConfortRequest(int SpeciesId, int MinimunAge, int MaximunAge,
        float MinimunTemperature, float MaximunTemperature,
        float MinimunHumidity, float MaximunHumidity,
        ConfortLevel Level) : ApplicationRequest;
}
