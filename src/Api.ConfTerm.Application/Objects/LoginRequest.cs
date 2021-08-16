using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects
{
    public record LoginRequest(Email Email, string Password);
}
