using Api.ConfTerm.Domain.ValueObjects;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class EspeciesController : BaseController
    {
        public EspeciesController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        public async Task<IActionResult> InsertSpecies([FromBody] InserirEspecieRequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }
    }
}
