using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoValidationDataAutomapper.Infrastructure.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
    }
}
