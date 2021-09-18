using Api.ConfTerm.Application.Objects;
using MediatR;

namespace Api.ConfTerm.Application.Abstract
{
    public interface IUseCase<in TRequest> : IRequestHandler<TRequest, ApplicationResponse> where TRequest : ApplicationRequest { }
}
