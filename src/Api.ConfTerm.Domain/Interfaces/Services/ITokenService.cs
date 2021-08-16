using Api.ConfTerm.Domain.Entities;

namespace Api.ConfTerm.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        public string GenerateTokenForUser(User user);
    }
}
