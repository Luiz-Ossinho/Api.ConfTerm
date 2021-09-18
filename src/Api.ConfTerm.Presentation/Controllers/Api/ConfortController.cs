using Api.ConfTerm.Domain.ValueObjects;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class ConfortoController : BaseController
    {
        public ConfortoController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("Itu")]
        public async Task<IActionResult> InsertTHIConfort([FromBody] InserirConfortoITURequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("Itgu")]
        public async Task<IActionResult> InsertBGTHIConfort([FromBody] InserirConfortoITGURequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("TemperaturaUmidade")]
        public async Task<IActionResult> InsertTHConfort([FromBody] InserirConfortoTemperaturaUmidadeRequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }
    }
}
