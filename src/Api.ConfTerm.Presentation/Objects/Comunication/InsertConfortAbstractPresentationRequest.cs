using System.Text.Json.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication
{
    public abstract record InsertConfortAbstractPresentationRequest(
        [property: JsonPropertyName("EspecieId")] int SpeciesId,
        [property: JsonPropertyName("IdadeMinima")] int MinimunAge,
        [property: JsonPropertyName("IdadeMaxima")] int MaximunAge,
        [property: JsonPropertyName("Nivel")] PresentationConfortLevel Level
    );
}
