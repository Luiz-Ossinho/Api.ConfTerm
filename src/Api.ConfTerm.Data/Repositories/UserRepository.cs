using Api.ConfTerm.Data.Contexts;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.ConfTerm.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _set;
        public UserRepository(MeasurementContext measurementContext)
        {
            _set = measurementContext.Set<User>();
        }

        public async Task<User> GetByEmailAsync(Email email)
            => await _set.FirstOrDefaultAsync(user => user.Email.Value == email.Value);

        public async Task InsertAsync(User user)
            => await _set.AddAsync(user);
    }
}
