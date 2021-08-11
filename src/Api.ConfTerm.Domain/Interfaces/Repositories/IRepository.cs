using Api.ConfTerm.Domain.Entities.Abstract;

namespace Api.ConfTerm.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : IdentifiableEntity
    {
        public TEntity GetById(int id);
        public void Insert(TEntity entity);
        public void DeleteById(int id);
    }
}
