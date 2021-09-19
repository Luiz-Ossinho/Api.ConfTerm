using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using FluentValidation;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Validation
{
    public class InsertBlackGlobeTemparuteHumidityIndexConfortPresentationRequestValidator : InsertConfortPresentationRequestValidator<InsertBlackGlobeTemparuteHumidityIndexConfortPresentationRequest>
    {
        public InsertBlackGlobeTemparuteHumidityIndexConfortPresentationRequestValidator() : base()
        {
            RuleFor(r => r.MinimunBGTHI)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThan(r => r.MaximunBGTHI);

            RuleFor(r => r.MaximunBGTHI)
                .NotEmpty()
                .GreaterThan(r => r.MinimunBGTHI);
        }
    }
}
