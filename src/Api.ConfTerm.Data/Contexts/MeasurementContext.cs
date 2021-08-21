using Api.ConfTerm.Data.Extensions;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.ConfTerm.Data.Contexts
{
    public class MeasurementContext : DbContext, IUnitOfWork
    {
        public MeasurementContext(DbContextOptions<MeasurementContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Housing> Housings { get; set; }
        public DbSet<AnimalProduction> AnimalProductions { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<TemperatureHumidityIndexConfort> THIConforts { get; set; }
        public DbSet<TemperatureHumidityConfort> TemperatureHumidityConforts { get; set; }
        public DbSet<BlackGlobeTemparuteHumidityIndexConfort> BGTHIConforts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyMappingConfigurations();

            base.OnModelCreating(modelBuilder);
        }
    }
}
