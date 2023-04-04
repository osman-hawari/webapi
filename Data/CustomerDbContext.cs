using Microsoft.EntityFrameworkCore;

namespace webapi.Data
{    
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customers");

            modelBuilder.Entity<Customer>().HasKey(p => p.Id);            

            base.OnModelCreating(modelBuilder);
        }
    }
}
