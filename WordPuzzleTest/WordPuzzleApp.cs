using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPuzzle.Configuration;

namespace WordPuzzle
{
    public static class WordPuzzleApp
    {
        public static void Run()
        {
            var wordPuzzleService = ConfigureApp.GetWordPuzzleServiceInstance();
        }
    }
}
