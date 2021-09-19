using System.Text.Json.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InsertSpeciesPresentationRequest(
        [property: JsonPropertyName("Nome")] string Name
    );
}
