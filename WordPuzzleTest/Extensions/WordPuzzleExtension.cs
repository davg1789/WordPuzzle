using System.Collections.Generic;
using System.Linq;

namespace WordPuzzle.Extensions
{
    public static class WordPuzzleExtension
    {
        public static List<string> Filter(this List<string> words)
        {
            words = words.Where(word => word.Length == 4).ToList();
            return words;
        }
    }
}
