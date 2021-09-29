using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InsertUserPresentationRequest(
        string Email,
        [property: JsonPropertyName("Nome")] string Name,
        [property: JsonPropertyName("Senha")] string Password,
        [property: JsonPropertyName("Tipo")] PresentationUserType Type
    );
}
