using Api.ConfTerm.Application.Objects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.ConfTerm.Presentation.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected readonly IMediator _mediator;

        protected IActionResult ActionResultOf(ApplicationResponse appResponse)
            => StatusCode((int)appResponse.StatusCode, appResponse.ToJsonObject());

    }
}
