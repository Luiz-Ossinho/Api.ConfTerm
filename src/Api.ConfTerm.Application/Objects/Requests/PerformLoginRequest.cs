using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record PerformLoginRequest(Email Email, string Password) : IApplicationRequest;
}
