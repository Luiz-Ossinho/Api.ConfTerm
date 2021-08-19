using Api.ConfTerm.Application.Objects.Requests;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InserirEspecieRequest(string Nome) : PresentationRequest<InsertSpeciesRequest>
    {
        public override InsertSpeciesRequest ToApplicationRequest()
            => new(Nome);
    }
}
