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
    public class AlojamentoController : BaseController
    {
        public AlojamentoController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        public async Task<IActionResult> InsertHousing([FromBody] InsertHousingPresentationRequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = _mapper.Map<InsertHousingRequest>(presentationRequest);
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }
    }
}
