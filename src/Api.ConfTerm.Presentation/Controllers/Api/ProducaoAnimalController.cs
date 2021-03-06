using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Domain.ValueObjects;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class ProducaoAnimalController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = nameof(UserType.Administrator))]
        public async Task<IActionResult> InsertAnimalProduction([FromServices] IInsertAnimalProductionUseCase useCase,
            [FromBody] InserirProducaoAnimalRequest presentationRequest)
        {
            var appRequest = presentationRequest.ToApplicationRequest();
            var appResponse = await useCase.HandleAsync(appRequest);
            return ActionResultOf(appResponse);
        }
    }
}
