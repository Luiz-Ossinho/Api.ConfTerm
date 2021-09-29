using System.Text.Json.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record PerformLoginPresentationRequest(
        string Email,
        [property: JsonPropertyName("Senha")] string Password
    );
}
