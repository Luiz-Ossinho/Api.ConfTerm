using System.Text.Json.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InsertMeasurementPresentationRequest(
        [property: JsonPropertyName("ProducaoAnimalId")] int AnimalProductionId,
        [property: JsonPropertyName("data")] string Date,
        [property: JsonPropertyName("horario")] string Time,
        [property: JsonPropertyName("itu")] float TemperatureHumidityIndex,
        [property: JsonPropertyName("itgu")] float BlackGlobeHumidityIndex,
        [property: JsonPropertyName("orvalho")] float DewPointTemperature,
        [property: JsonPropertyName("tbs")] float DryBulbTemperature,
        [property: JsonPropertyName("BulboUmido")] float WetBulbTemperature,
        [property: JsonPropertyName("umidade")] float Humidity,
        [property: JsonPropertyName("tg")] float BlackGlobeTemperature
    );
}
