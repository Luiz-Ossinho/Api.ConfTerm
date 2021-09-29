using FluentValidation;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Validation
{
    public class InsertConfortPresentationRequestValidator<TInsertConfortPresentationRequest> :
        AbstractValidator<TInsertConfortPresentationRequest>
        where TInsertConfortPresentationRequest : InsertConfortAbstractPresentationRequest
    {
        public InsertConfortPresentationRequestValidator()
        {
            RuleFor(r => r.SpeciesId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(r => r.MinimunAge)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThan(r=>r.MaximunAge);

            RuleFor(r => r.MaximunAge)
                .NotEmpty()
                .GreaterThan(r=>r.MaximunAge);

            RuleFor(r => r.Level)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
