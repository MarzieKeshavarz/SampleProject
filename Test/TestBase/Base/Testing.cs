using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Infrastructure.DbContexts;
using SampleProject.Presentation.Server;
using Respawn;

namespace ServiceTestBase.Base
{
    public class Testing
    {
        protected static IConfigurationRoot _configuration;
        protected static IServiceScopeFactory _scopeFactory;
        protected static ApplicationDbContext _context;
        protected static Checkpoint _checkpoint;

        public Testing()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var services = new ServiceCollection();

            var startup = new Startup(_configuration);

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "SampleProject"));

            startup.ConfigureServices(services);


            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
            
            var scope = _scopeFactory.CreateScope();


            EnsureDatabase();

            _context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new Respawn.Graph.Table[] { "__EFMigrationsHistory" }
            };

            _checkpoint.Reset(_configuration.GetConnectionString("Main"));
        }

        private void EnsureDatabase()
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.Migrate();
            
            _context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        }

    }
}
