using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Domain.ValueObjects;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class ConfortoController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("Itu")]
        public async Task<IActionResult> InsertTHIConfort([FromServices] IInsertTHIConfortUseCase useCase, [FromBody] InserirConfortoITURequest presentationRequest)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await useCase.HandleAsync(appRequest);
            return ActionResultOf(appResponse);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("Itgu")]
        public async Task<IActionResult> InsertBGTHIConfort([FromServices] IInsertBGTHIConfortUseCase useCase, [FromBody] InserirConfortoITGURequest presentationRequest)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await useCase.HandleAsync(appRequest);
            return ActionResultOf(appResponse);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        [Route("TemperaturaUmidade")]
        public async Task<IActionResult> InsertTHConfort([FromServices] IInsertTemperatureHumidityConfortUseCase useCase,
            [FromBody] InserirConfortoTemperaturaUmidadeRequest presentationRequest)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await useCase.HandleAsync(appRequest);
            return ActionResultOf(appResponse);
        }
    }
}
