using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Requests;

namespace Api.ConfTerm.Application.Abstract.UseCases
{
    public interface IInsertHousingUseCase : IUseCase<InsertHousingRequest, ApplicationResponse>
    {
    }
}
