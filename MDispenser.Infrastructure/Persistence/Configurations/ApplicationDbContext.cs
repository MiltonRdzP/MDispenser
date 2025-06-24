using MDispenser.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MDispenser.Infrastructure.Persistence.Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<UserHomeAccess> UserHomeAccesses { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceEvent> DeviceEvents { get; set; }

        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<DeviceAction> DeviceActions { get; set; }
        public DbSet<DispenseLog> DispenseLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new HomeConfiguration());
            modelBuilder.ApplyConfiguration(new UserHomeAccessConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceEventConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceActionConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DispenseLogConfiguration());
        }
    }
}
