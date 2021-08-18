using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record LoginRequest(Email Email, string Password);
}
