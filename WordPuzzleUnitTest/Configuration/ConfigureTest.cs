using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPuzzle.Service.Implementaiton;
using WordPuzzle.Service.Interface;

namespace WordPuzzleUnitTest.Configuration
{
    public static class ConfigureTest
    {
        public static IWordPuzzleService GetService() 
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IWordPuzzleService, WordPuzzleService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider.GetService<IWordPuzzleService>();
        }
    }
}
