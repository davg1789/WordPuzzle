using Microsoft.Extensions.DependencyInjection;
using WordPuzzle.Repositories.Implementaiton;
using WordPuzzle.Repositories.Interface;
using WordPuzzle.Services.Implementaiton;
using WordPuzzle.Services.Interface;

namespace WordPuzzle.Configuration
{
    public static class ConfigureApp
    {
        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddScoped<IWordPuzzleService, WordPuzzleService>();
            services.AddScoped<IWordPuzzleRepository, WordPuzzleRepository>();
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
