using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InserirUsuarioRequest(string Email, string Nome, string Senha, int Tipo) : PresentationRequest<InsertUserRequest>
    {
        public override InsertUserRequest ToApplicationRequest()
            => new(new Email(Email), Senha, Nome, UserType.GetValid(Tipo));
    }
}
