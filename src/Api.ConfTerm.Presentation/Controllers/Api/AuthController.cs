using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Domain.Enums;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class AuthController : BaseController
    {
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> PerformLogin([FromServices] IPerformLoginUseCase useCase, [FromBody] RealizarLoginRequest presentationRequest)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await useCase.HandleAsync(appRequest);
            return ActionResultOf(appResponse);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("User")]
        public async Task<IActionResult> InsetUser([FromServices] IInsertUserUseCase useCase, [FromBody] InserirUsuarioRequest presentationRequest)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await useCase.HandleAsync(appRequest);
            return ActionResultOf(appResponse);
        }
    }
}
