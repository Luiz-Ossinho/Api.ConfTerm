using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InserirConfortoITGURequest(int EspecieId, int IdadeMinima, int IdadeMaxima, int Nivel, float ItguMinimo,
        float ItguMaximo) : PresentationRequest<InsertBGTHIConfortRequest>
    {
        public override InsertBGTHIConfortRequest ToApplicationRequest()
            => new(EspecieId, IdadeMinima, IdadeMaxima, ItguMinimo, ItguMaximo, ConfortLevel.GetValid(Nivel));
    }
}
