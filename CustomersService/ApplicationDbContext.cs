using CustomersService.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomersService
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Customer)
                .HasForeignKey<CustomerAddress>(a => a.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Contacts)
                .WithOne(cc => cc.Customer)
                .HasForeignKey(cc => cc.CustomerId);
        }
    }
}
