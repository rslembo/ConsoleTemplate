using ConsoleTemplate.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ConsoleTemplate.Services
{
    public class App : IApp
    {
        public IConfiguration Configuration { get; set; }
        public IProductFinder ProductFinder { get; set; }

        public App(IConfiguration configuration, IProductFinder productFinder)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ProductFinder = productFinder ?? throw new ArgumentNullException(nameof(productFinder));
        }

        public async Task Run()
        {
            Console.WriteLine(Configuration.GetSection("AppSettings")["HelloMessage"]);

            var products = await ProductFinder.FindAll();
            var product = await ProductFinder.FindById(Guid.Parse("320E9F1F-4FC0-47E4-9D64-BA05B9BEEF02"));
        }
    }
}