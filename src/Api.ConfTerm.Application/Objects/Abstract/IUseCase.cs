using MediatR;

namespace Api.ConfTerm.Application.Objects.Abstract
{
    public interface IUseCase<in TRequest> : IRequestHandler<TRequest, ApplicationResponse> where TRequest : IApplicationRequest { }
}
