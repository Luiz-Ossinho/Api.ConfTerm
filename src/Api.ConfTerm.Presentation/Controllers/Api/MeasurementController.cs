using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.ConfTerm.Presentation.Controllers.Api
{
    public class MeasurementController : BaseController
    {
        [HttpPost]
        public IActionResult InsertMeasurement([FromServices] IInsertMeasurementUseCase useCase, [FromBody] InserirMedicaoRequest resquestBody)
        {
            var appRequest = resquestBody.ToApplicationRequest();

            var appResponse = useCase.Handle(appRequest);

            return ActionResultOf(appResponse);
        }
    }
}
