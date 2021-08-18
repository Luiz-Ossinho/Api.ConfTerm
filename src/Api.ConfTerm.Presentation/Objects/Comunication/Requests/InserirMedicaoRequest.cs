using Api.ConfTerm.Application.Objects.Requests;
using System;
using System.Linq;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InserirMedicaoRequest(int ProducaoAnimalId, string data, string horario, float itu, float itgu, 
        float orvalho, float tbs, float BulboUmido, float umidade, float tg) : IPresentationRequest<MeasurementRequest>
    {
        public MeasurementRequest ToApplicationRequest()
        {
            var horarioSplit = horario.Split(":").Select(str => int.Parse(str)).ToArray();
            var dataSplit = data.Split("/").Select(str => int.Parse(str)).ToArray();
            var measurementDateTime = new DateTime(dataSplit[2], dataSplit[1], dataSplit[0], horarioSplit[0], horarioSplit[1], horarioSplit[2]);
            return new MeasurementRequest(ProducaoAnimalId, measurementDateTime, itu, itgu, orvalho, tbs, BulboUmido, umidade, tg);
        }
    }
}
