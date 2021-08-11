using Api.ConfTerm.Domain.Entities.Abstract;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Api.ConfTerm.Data.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : IdentifiableEntity
    {
        private readonly MeasurementContext _measurementContext;
        protected DbSet<TEntity> Set { get; set; }
        public GenericRepository(MeasurementContext measurementContext)
        {
            _measurementContext = measurementContext;
            Set = _measurementContext.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            Set.Add(entity);
            _measurementContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Set.Remove(GetById(id));
            _measurementContext.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Set.FirstOrDefault(entity => entity.Id == id);
        }
    }
}
