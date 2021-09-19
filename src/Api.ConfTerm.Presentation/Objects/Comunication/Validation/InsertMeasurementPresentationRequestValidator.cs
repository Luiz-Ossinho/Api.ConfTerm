using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using FluentValidation;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Validation
{
    public class InsertMeasurementPresentationRequestValidator : AbstractValidator<InsertMeasurementPresentationRequest>
    {
        public InsertMeasurementPresentationRequestValidator()
        {
            RuleFor(r => r.AnimalProductionId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.Date)
                .NotEmpty()
                .Matches(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$");

            RuleFor(r => r.Time)
                .NotEmpty()
                .Matches(@"^(?:(?:([01]?\d|2[0-3]):)?([0-5]?\d):)?([0-5]?\d)$");

            RuleFor(r => r.BlackGlobeHumidityIndex)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.BlackGlobeTemperature)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.DewPointTemperature)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.DryBulbTemperature)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.Humidity)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.TemperatureHumidityIndex)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.WetBulbTemperature)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
