using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entity;

namespace MinimalApi.Infrastructure.DB
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration _configurationAppSettings;
        private readonly TypeDb _typeDb;
        public DBContext(IConfiguration configurationAppSettings, TypeDb typeDb = TypeDb.Sqlite)
        {
            _configurationAppSettings = configurationAppSettings;
            _typeDb = typeDb;
        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (_typeDb == TypeDb.Sqlite)
            {
                modelBuilder.Entity<Administrator>().HasData(new Administrator { Id = 1, Email = "administrador@teste.com", Password = "123456", Profile = "Adm" });
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (_typeDb == TypeDb.Sqlite)
                {
                    optionsBuilder.UseSqlite((_configurationAppSettings.GetConnectionString("DefaultConnection") ?? string.Empty).ToString());
                }
                else
                {
                    optionsBuilder.UseInMemoryDatabase("DefaultConnection");
                }
            }
        }
    }
}
