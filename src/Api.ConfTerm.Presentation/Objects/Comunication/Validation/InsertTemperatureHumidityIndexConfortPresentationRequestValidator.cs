using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using FluentValidation;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Validation
{
    public class InsertTemperatureHumidityIndexConfortPresentationRequestValidator : InsertConfortPresentationRequestValidator<InsertTemperatureHumidityIndexConfortPresentationRequest>
    {
        public InsertTemperatureHumidityIndexConfortPresentationRequestValidator() : base()
        {
            RuleFor(r => r.MinimunTHI)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThan(r => r.MaximunTHI);

            RuleFor(r => r.MaximunTHI)
                .NotEmpty()
                .GreaterThan(r => r.MinimunTHI);
        }
    }
}
