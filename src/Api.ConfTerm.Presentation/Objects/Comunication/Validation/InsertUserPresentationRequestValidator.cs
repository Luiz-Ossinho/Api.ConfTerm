using Api.ConfTerm.Domain.ValueObjects;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using FluentValidation;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Validation
{
    public class InsertUserPresentationRequestValidator : AbstractValidator<InsertUserPresentationRequest>
    {
        public InsertUserPresentationRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .MaximumLength(255)
                .Must(r => Email.IsValid(new Email(r))).WithMessage(r => $"is not a valid email");
            RuleFor(r => r.Password)
                .NotEmpty()
                .MaximumLength(255);
            RuleFor(r => r.Type)
                .NotEmpty()
                .IsInEnum();
            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
