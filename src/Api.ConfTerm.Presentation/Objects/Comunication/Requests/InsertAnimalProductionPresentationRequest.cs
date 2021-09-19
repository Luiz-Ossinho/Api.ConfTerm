using System.Text.Json.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InsertAnimalProductionPresentationRequest(
        [property: JsonPropertyName("AlojamentoId")] int HousingId,
        [property: JsonPropertyName("EspecieId")] int SpeciesId,
        [property: JsonPropertyName("Nascimento")] string BirthDay,
        [property: JsonPropertyName("InicioMonitoramento")] string MonitoringStart,
        [property: JsonPropertyName("FimMonitoramento")] string MonitoringEnd,
        [property: JsonPropertyName("Equipamento")] string Equipament
    );
}
