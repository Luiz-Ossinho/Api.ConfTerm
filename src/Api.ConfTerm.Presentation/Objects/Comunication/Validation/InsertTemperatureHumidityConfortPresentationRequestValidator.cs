using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using FluentValidation;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Validation
{
    public class InsertTemperatureHumidityConfortPresentationRequestValidator : InsertConfortPresentationRequestValidator<InsertTemperatureHumidityConfortPresentationRequest>
    {
        public InsertTemperatureHumidityConfortPresentationRequestValidator() : base()
        {
            RuleFor(r => r.MinimunHumidity)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThan(r => r.MaximunHumidity);

            RuleFor(r => r.MaximunHumidity)
                .NotEmpty()
                .GreaterThan(r => r.MinimunHumidity);

            RuleFor(r => r.MinimunTemperature)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThan(r => r.MaximunTemperature);

            RuleFor(r => r.MaximunTemperature)
                .NotEmpty()
                .GreaterThan(r => r.MinimunTemperature);
        }
    }
}
