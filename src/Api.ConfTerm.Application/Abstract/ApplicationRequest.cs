using Api.ConfTerm.Application.Objects;
using MediatR;

namespace Api.ConfTerm.Application.Abstract
{
    public abstract record ApplicationRequest : IRequest<ApplicationResponse> { }
}
