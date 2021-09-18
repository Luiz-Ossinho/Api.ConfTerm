using Api.ConfTerm.Domain.ValueObjects;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> PerformLogin([FromBody] RealizarLoginRequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("User")]
        public async Task<IActionResult> InsetUser([FromBody] InserirUsuarioRequest presentationRequest, CancellationToken cancellationToken = default)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await _mediator.Send(appRequest, cancellationToken);
            return ActionResultOf(appResponse);
        }
    }
}
