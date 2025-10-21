using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProjetoSOLID.Infrastructure.Data
{
    public class ProjetoDbContextFactory : IDesignTimeDbContextFactory<ProjetoDbContext>
    {
        public ProjetoDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ProjetoDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ProjetoDbContext(optionsBuilder.Options);
        }
    }
}
