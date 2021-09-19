using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertUserRequest(Email Email, string Password, string Name, UserType Type) : IApplicationRequest;
}
