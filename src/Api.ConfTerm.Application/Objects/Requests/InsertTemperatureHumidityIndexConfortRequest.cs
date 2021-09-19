using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertTemperatureHumidityIndexConfortRequest(
        int SpeciesId,
        int MinimunAge,
        int MaximunAge,
        ConfortLevel Level,
        float MinimunTHI,
        float MaximunTHI
    ) : InsertConfortAbstractRequest(SpeciesId, MinimunAge, MaximunAge, Level);
}
