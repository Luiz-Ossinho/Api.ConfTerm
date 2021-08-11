using Api.ConfTerm.Application.Objects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected IActionResult ActionResultOf(ApplicationResponse appResponse)
            => StatusCode((int)appResponse.StatusCode, appResponse.ToJsonObject());
    }
}
