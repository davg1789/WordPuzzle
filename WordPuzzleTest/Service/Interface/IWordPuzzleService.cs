using System.Collections.Generic;

namespace WordPuzzle.Service.Interface
{
    public interface IWordPuzzleService
    {
        public List<string> GetWords(string startWord, string endWord);
        public bool SaveWords(List<string> words);
    }
}
