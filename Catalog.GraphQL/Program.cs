using System;
using Catalog.Infrastructure.DataAccess;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.GraphQL
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var webhost = BuildWebHost(args);
            MigrateDbContext(webhost, CatalogDbContextInitializer.Initialize);
            webhost.Run();
        }

        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

        public static IWebHost MigrateDbContext(IWebHost webHost, Action<CatalogDbContext> initializer)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
                initializer(context);
            }

            return webHost;
        }
    }
}
