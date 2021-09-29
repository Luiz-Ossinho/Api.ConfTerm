using MediatR;

namespace Api.ConfTerm.Application.Objects.Abstract
{
    public interface IApplicationRequest : IRequest<ApplicationResponse> { }
}
