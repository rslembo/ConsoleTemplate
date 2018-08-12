using ConsoleTemplate.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ConsoleTemplate
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = ServiceProviderBuilder.Build();
            await serviceProvider.GetService<IApp>().Run();
        }
    }
}