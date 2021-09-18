using Api.ConfTerm.Domain.Entities.Abstract;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Api.ConfTerm.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IdentifiableEntity
    {
        protected readonly DbSet<TEntity> _set;
        public Repository(MeasurementContext measurementContext)
        {
            _set = measurementContext.Set<TEntity>();
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
            => _set.Remove(await GetByIdAsync(id, cancellationToken));

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => await _set.FindAsync(new object[] { id }, cancellationToken: cancellationToken);

        public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
            => await _set.AddAsync(entity, cancellationToken: cancellationToken);
    }
}
