using Api.ConfTerm.Presentation.Objects.Comunication.Mapping;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using FluentValidation;
using System;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Validation
{
    public class InsertAnimalProductionPresentationRequestValidator : AbstractValidator<InsertAnimalProductionPresentationRequest>
    {
        public InsertAnimalProductionPresentationRequestValidator()
        {
            RuleFor(r => r.SpeciesId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.SpeciesId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.BirthDay)
                .NotEmpty()
                .Matches(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$");

            RuleFor(r => r.MonitoringStart)
                .NotEmpty()
                .Matches(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$");

            RuleFor(r => r.MonitoringEnd)
                .Matches(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$")
                .When(r => r.MonitoringEnd != (default(DateTime)).ToString("yyyy/dd/MM"))
                .Must((r, end) => PresentationToApplicationProfile.GetDateFromPresentationRequest(end) >= PresentationToApplicationProfile.GetDateFromPresentationRequest(r.MonitoringStart))
                .When(r => r.MonitoringEnd != (default(DateTime)).ToString("yyyy/dd/MM"));

            RuleFor(r => r.Equipament)
                .NotEmpty()
                .When(e => e != default)
                .MaximumLength(255)
                .When(e => e != default);
        }
    }
}
