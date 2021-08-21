using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.ValueObjects; 

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InserirConfortoITURequest(int EspecieId, int IdadeMinima, int IdadeMaxima, int Nivel, float ItuMinimo, 
        float ItuMaximo) : PresentationRequest<InsertTHIConfortRequest>
    {
        public override InsertTHIConfortRequest ToApplicationRequest()
            => new(EspecieId, IdadeMinima, IdadeMaxima, ItuMinimo, ItuMaximo, ConfortLevel.GetValid(Nivel));
    }
}
