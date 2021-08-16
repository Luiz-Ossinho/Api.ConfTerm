using Api.ConfTerm.Domain.Entities.Abstract;
using System.Threading.Tasks;

namespace Api.ConfTerm.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : IdentifiableEntity
    {
        public Task<TEntity> GetByIdAsync(int id);
        public Task InsertAsync(TEntity entity);
        public Task DeleteByIdAsync(int id);
    }
}
