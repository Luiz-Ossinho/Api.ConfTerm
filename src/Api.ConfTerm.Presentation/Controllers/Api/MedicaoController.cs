using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class MedicaoController : BaseController
    {
        public MedicaoController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> InsertMeasurement([FromBody] InserirMedicaoRequest resquestBody, CancellationToken cancellationToken = default)
        {
            var appRequest = resquestBody.ToApplicationRequest();
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }
    }
}
