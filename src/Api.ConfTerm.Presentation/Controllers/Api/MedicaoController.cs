using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class MedicaoController : BaseController
    {
        public MedicaoController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        public async Task<IActionResult> InsertMeasurement([FromBody] InsertMeasurementPresentationRequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = _mapper.Map<InsertMeasurementRequest>(presentationRequest);
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }
    }
}
