using Api.ConfTerm.Domain.ValueObjects;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using FluentValidation;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Validation
{
    public class InsertHousingPresentationRequestValidator : AbstractValidator<InsertHousingPresentationRequest>
    {
        public InsertHousingPresentationRequestValidator()
        {
            RuleFor(r => r.Identificantion)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(r => r.UserEmail)
                .NotEmpty()
                .MaximumLength(255)
                .Must(r => Email.IsValid(new Email(r))).WithMessage(r => $"is not a valid email");
        }
    }
}
