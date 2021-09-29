using Api.ConfTerm.Application.Objects;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.ConfTerm.Presentation.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        protected BaseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        protected IActionResult ActionResultOf(ApplicationResponse appResponse)
            => StatusCode((int)appResponse.StatusCode, appResponse);

    }
}
