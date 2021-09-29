using System.Text.Json.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InsertTemperatureHumidityConfortPresentationRequest(
        int SpeciesId,
        int MinimunAge,
        int MaximunAge,
        PresentationConfortLevel Level,
        [property: JsonPropertyName("TemperaturaMinima")] float MinimunTemperature,
        [property: JsonPropertyName("TemperaturaMaxima")] float MaximunTemperature,
        [property: JsonPropertyName("UmidadeMinima")] float MinimunHumidity,
        [property: JsonPropertyName("UmidadeMaxima")] float MaximunHumidity
    ) : InsertConfortAbstractPresentationRequest(SpeciesId, MinimunAge, MaximunAge, Level);
}
