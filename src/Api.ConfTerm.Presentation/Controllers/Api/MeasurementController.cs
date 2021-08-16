using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class MeasurementController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> InsertMeasurement([FromServices] IInsertMeasurementUseCase useCase, [FromBody] InserirMedicaoRequest resquestBody)
        {
            var appRequest = resquestBody.ToApplicationRequest();

            var appResponse = await useCase.HandleAsync(appRequest);

            return ActionResultOf(appResponse);
        }
    }
}
