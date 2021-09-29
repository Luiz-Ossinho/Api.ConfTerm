using Api.ConfTerm.Application.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ConfTerm.Presentation.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var appResponse = ApplicationResponse.OfOk();

                var appErrors = context.ModelState.Keys.SelectMany(k => context.ModelState[k].Errors.Select(e => ApplicationError.Of(e.ErrorMessage, k)));

                appResponse.WithBadRequest(appErrors.ToArray());

                context.Result = new BadRequestObjectResult(appResponse);
                return;
            }

            await next();
        }
    }
}
