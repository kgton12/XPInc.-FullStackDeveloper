using Microsoft.Extensions.Configuration;
using MinimalApi.Infrastructure.DB;

namespace MinimalApi.Test.DB
{
    public class DbContextTest
    {
        public static DBContext GetDbContextTest()
        {
            IConfiguration configurationAppSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return new DBContext(configurationAppSettings, TypeDb.InMemory);
        }
    }
}
