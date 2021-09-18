using Api.ConfTerm.Data.Contexts;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MeasurementContext measurementContext) : base(measurementContext) { }

        public async Task<User> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
            => await _set.FirstOrDefaultAsync(user => user.Email.Value == email.Value, cancellationToken: cancellationToken);
    }
}
