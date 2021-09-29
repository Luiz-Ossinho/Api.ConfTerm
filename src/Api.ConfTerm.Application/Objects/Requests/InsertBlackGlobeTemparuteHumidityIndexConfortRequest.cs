using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertBlackGlobeTemparuteHumidityIndexConfortRequest(
        int SpeciesId,
        int MinimunAge,
        int MaximunAge,
        ConfortLevel Level,
        float MinimunBGTHI,
        float MaximunBGTHI
    ) : InsertConfortAbstractRequest(SpeciesId, MinimunAge, MaximunAge, Level);
}
