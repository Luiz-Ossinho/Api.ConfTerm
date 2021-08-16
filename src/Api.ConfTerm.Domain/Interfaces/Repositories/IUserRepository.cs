using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Api.ConfTerm.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetByEmailAsync(Email email);
        public Task InsertAsync(User user);
    }
}
