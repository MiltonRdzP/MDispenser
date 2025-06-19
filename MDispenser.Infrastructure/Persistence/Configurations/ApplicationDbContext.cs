using MDispenser.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MDispenser.Infrastructure.Persistence.Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Dispenser> Dispensers => Set<Dispenser>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dispenser>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Name).IsRequired();
                entity.Property(d => d.LastDispenseTime).IsRequired();
            });

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
