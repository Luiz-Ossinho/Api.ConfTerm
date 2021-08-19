using Api.ConfTerm.Application.Objects.Requests;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InserirProducaoAnimalRequest(int AlojamentoId, int EspecieId,
        string DataNascimento, string DataInicioMonitoramento, string DataFimMonitoramento, string Equipamento)
        : PresentationRequest<InsertAnimalProductionRequest>
    {
        public override InsertAnimalProductionRequest ToApplicationRequest()
            => new(AlojamentoId, EspecieId,
                GetDateFromPresentationString(DataNascimento),
                GetDateFromPresentationString(DataInicioMonitoramento),
                GetDateFromPresentationString(DataFimMonitoramento),
                Equipamento);

    }
}
