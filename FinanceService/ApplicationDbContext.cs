using FinanceService.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceService
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<IncomingPayment> IncomingPayments { get; set; }
        public DbSet<IncomingPaymentItem> IncomingPaymentItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IncomingPayment>()
                .HasMany(ip => ip.IncomingPaymentItems)
                .WithOne(ipi => ipi.IncomingPayment)
                .HasForeignKey(ipi => ipi.IncomingPaymentId);
        }
    }
}
