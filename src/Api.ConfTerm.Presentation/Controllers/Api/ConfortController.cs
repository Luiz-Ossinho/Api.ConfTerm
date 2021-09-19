using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.ValueObjects;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class ConfortoController : BaseController
    {
        public ConfortoController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("Itu")]
        public async Task<IActionResult> InsertTHIConfort([FromBody] InsertTemperatureHumidityIndexConfortPresentationRequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = _mapper.Map<InsertTemperatureHumidityIndexConfortRequest>(presentationRequest);
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("Itgu")]
        public async Task<IActionResult> InsertBGTHIConfort([FromBody] InsertBlackGlobeTemparuteHumidityIndexConfortPresentationRequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = _mapper.Map<InsertBlackGlobeTemparuteHumidityIndexConfortRequest>(presentationRequest);
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("TemperaturaUmidade")]
        public async Task<IActionResult> InsertTHConfort([FromBody] InsertTemperatureHumidityConfortPresentationRequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = _mapper.Map<InsertTemperatureHumidityConfortRequest>(presentationRequest);
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }
    }
}
