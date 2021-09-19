using System.Text.Json.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InsertHousingPresentationRequest(
        [property: JsonPropertyName("Indentificao")] string Identificantion,
        [property: JsonPropertyName("Email")] string UserEmail
    );
}
 