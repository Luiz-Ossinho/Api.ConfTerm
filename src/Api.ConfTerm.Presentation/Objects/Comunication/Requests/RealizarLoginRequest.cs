using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record RealizarLoginRequest(string Email, string Senha) : PresentationRequest<LoginRequest>
    {
        public override LoginRequest ToApplicationRequest()
            => new(new Email(Email), Senha);
    }
}
