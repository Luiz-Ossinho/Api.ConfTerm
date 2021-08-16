using Api.ConfTerm.Data.Extensions;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.ConfTerm.Data.Contexts
{
    public class MeasurementContext : DbContext, IUnitOfWork
    {
        public MeasurementContext(DbContextOptions<MeasurementContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Housing> Housings { get; set; }
        public DbSet<AnimalProduction> AnimalProductions { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //    // optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=SchoolDB;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyMappingConfigurations()
                .ApplyManyToManyMappingConfigurations();
        }
    }
}
