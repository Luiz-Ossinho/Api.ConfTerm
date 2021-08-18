using Api.ConfTerm.Application.Objects.Requests;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InserirProducaoAnimalRequest(int AlojamentoId, string DataNascimento, string DataInicioMonitoramento, string DataFimMonitoramento, string Equipamento)
        : PresentationRequest<InsertAnimalProductionRequest>
    {
        public override InsertAnimalProductionRequest ToApplicationRequest()
            => new(AlojamentoId, GetDateFromPresentationString(DataNascimento),
                GetDateFromPresentationString(DataInicioMonitoramento),
                GetDateFromPresentationString(DataFimMonitoramento), Equipamento);

    }
}
