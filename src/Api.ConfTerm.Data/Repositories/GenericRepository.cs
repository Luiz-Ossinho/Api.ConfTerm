using Api.ConfTerm.Domain.Entities.Abstract;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.ConfTerm.Data.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : IdentifiableEntity
    {
        protected readonly DbSet<TEntity> _set;
        public GenericRepository(MeasurementContext measurementContext)
        {
            _set = measurementContext.Set<TEntity>();
        }

        public async Task InsertAsync(TEntity entity)
            => await _set.AddAsync(entity);

        public async Task DeleteByIdAsync(int id)
            => _set.Remove(await GetByIdAsync(id));

        public async Task<TEntity> GetByIdAsync(int id)
            => await _set.FindAsync(id);
    }
}
