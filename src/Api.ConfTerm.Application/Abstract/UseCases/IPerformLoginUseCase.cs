using Api.ConfTerm.Application.Objects;

namespace Api.ConfTerm.Application.Abstract.UseCases
{
    public interface IPerformLoginUseCase : IUseCase<LoginRequest, ApplicationResponse>
    {
    }
}
