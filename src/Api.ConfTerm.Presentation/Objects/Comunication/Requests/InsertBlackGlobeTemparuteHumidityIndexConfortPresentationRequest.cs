using System.Text.Json.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InsertBlackGlobeTemparuteHumidityIndexConfortPresentationRequest(
        int SpeciesId,
        int MinimunAge,
        int MaximunAge,
        PresentationConfortLevel Level,
        [property: JsonPropertyName("ItguMinimo")] float MinimunBGTHI,
        [property: JsonPropertyName("ItguMaximo")] float MaximunBGTHI
    ) : InsertConfortAbstractPresentationRequest(SpeciesId, MinimunAge, MaximunAge, Level);
}
