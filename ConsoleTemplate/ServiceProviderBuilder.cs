using ConsoleTemplate.Repositories;
using ConsoleTemplate.Repositories.Interfaces;
using ConsoleTemplate.Services;
using ConsoleTemplate.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ConsoleTemplate
{
    public static class ServiceProviderBuilder
    {
        public static IServiceProvider Build()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            serviceCollection.AddTransient<IApp, App>();
            serviceCollection.AddTransient<IProductFinder, ProductFinder>();

            serviceCollection.AddTransient<IProductRepository, ProductRepository>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}