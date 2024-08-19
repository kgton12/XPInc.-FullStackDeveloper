using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entity;

namespace MinimalApi.Infrastructure.DB
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration _configurationAppSettings;
        public DBContext(IConfiguration configurationAppSettings)
        {
            _configurationAppSettings = configurationAppSettings;
        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().HasData(new Administrator { Id = 1, Email = "administrador@teste.com", Password = "123456", Profile = "Adm" });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite((_configurationAppSettings.GetConnectionString("DefaultConnection") ?? string.Empty).ToString());
            }
        }
    }
}
