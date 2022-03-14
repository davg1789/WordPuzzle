using Microsoft.Extensions.DependencyInjection;
using WordPuzzle.Repositories.Implementaiton;
using WordPuzzle.Repositories.Interface;
using WordPuzzle.Services.Implementaiton;
using WordPuzzle.Services.Interface;

namespace WordPuzzleUnitTest.Configuration
{
    public static class ConfigureTest
    {
        public static IWordPuzzleService GetService() 
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IWordPuzzleService, WordPuzzleService>();
            serviceCollection.AddScoped<IWordPuzzleRepository, WordPuzzleRepository>();            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider.GetService<IWordPuzzleService>();
        }
    }
}
