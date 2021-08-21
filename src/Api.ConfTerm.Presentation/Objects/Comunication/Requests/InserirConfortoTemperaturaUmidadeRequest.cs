using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InserirConfortoTemperaturaUmidadeRequest(int EspecieId, int IdadeMinima, int IdadeMaxima, int Nivel,
        float TemperaturaMinima, float TemperaturaMaxima,
        float UmidadeMinima, float UmidadeMaxima) : PresentationRequest<InsertTemperatureHumidityConfortRequest>
    {
        public override InsertTemperatureHumidityConfortRequest ToApplicationRequest()
            => new(EspecieId, IdadeMinima, IdadeMaxima, TemperaturaMinima, TemperaturaMaxima, UmidadeMinima, UmidadeMaxima, ConfortLevel.GetValid(Nivel));
    }
}
