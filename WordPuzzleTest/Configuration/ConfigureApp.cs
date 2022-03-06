using Microsoft.Extensions.DependencyInjection;
using WordPuzzle.Service.Implementaiton;
using WordPuzzle.Service.Interface;

namespace WordPuzzle.Configuration
{
    public static class ConfigureApp
    {
        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddScoped<IWordPuzzleService, WordPuzzleService>();
        }

        public static IWordPuzzleService GetWordPuzzleServiceInstance()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureDI();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider.GetService<IWordPuzzleService>();
        }
    }
}
