using Infrastructure.DbContexts;
using Microsoft.Extensions.Configuration;
using Respawn;
using System.IO;

namespace TestBase.Base
{
    public class DbFixture
    {
        protected static ApplicationDbContext _context1;

        private static readonly Checkpoint Checkpoint = new Checkpoint
        {
            TablesToIgnore = new Respawn.Graph.Table[] { "__EFMigrationsHistory" }
        };

        public DbFixture()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            Checkpoint.Reset(configuration.GetConnectionString("Main"));
        }
    }
}
