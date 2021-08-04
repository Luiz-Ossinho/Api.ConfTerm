using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ConfTerm.Data.Extensions
{
    public static class EntityTypeConfigurationExentensions
    {
        public static ModelBuilder ApplyMappingConfigurations(this ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductMap());
            //modelBuilder.ApplyConfiguration(new CategoryMap());
            //modelBuilder.ApplyConfiguration(new OptionMap());
            //modelBuilder.ApplyConfiguration(new ItemMap());

            //modelBuilder.ApplyConfiguration(new CustomerMap());
            //modelBuilder.ApplyConfiguration(new CompanyMap());
            //modelBuilder.ApplyConfiguration(new ProfileMap());
            //modelBuilder.ApplyConfiguration(new ProfileHistoricMap());
            //modelBuilder.ApplyConfiguration(new CompanyTypeMap());

            //modelBuilder.ApplyConfiguration(new AddressMap());

            return modelBuilder;
        }

        public static ModelBuilder ApplyManyToManyMappingConfigurations(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasMany(product => product.Options).WithMany(option => option.Products);
            //modelBuilder.Entity<Company>().HasMany(company => company.Owners).WithMany(customer => customer.Companies);
            return modelBuilder;
        }
    }
}
