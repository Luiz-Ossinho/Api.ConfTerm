using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using FluentValidation;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Validation
{
    public class InsertSpeciesPresentationRequestValidator : AbstractValidator<InsertSpeciesPresentationRequest>
    {
        public InsertSpeciesPresentationRequestValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
