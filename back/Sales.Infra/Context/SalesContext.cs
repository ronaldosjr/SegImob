using Microsoft.EntityFrameworkCore;
using Sales.Infra.Helpers;
using Sales.Infra.Mapping;

namespace Sales.Infra.Context
{
    public class SalesContext : DbContext
    {
        public readonly DbContextOptions<SalesContext> Options;

        public SalesContext() { }

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {
            Options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(
                 "server=localhost;user id=postgres;password=postgres;persistsecurityinfo=True;database=sales;Pooling=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new SalesMapping());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                    property.Relational().ColumnName = property.Name.ToUnderscoreCase();
            }

        }
    }
}

