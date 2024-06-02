using Microsoft.EntityFrameworkCore;
using ProductsService.Common.Entities;

namespace ProductsService
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>()
                .HasOne(p => p.Category)
                .WithOne()
                .HasForeignKey<Unit>(p => p.CategoryId);
        }
    }
}
