using System;
using System.Collections.Generic;
using System.Linq;
using WordPuzzle.Service.Interface;

namespace WordPuzzle.Service.Implementaiton
{
    public class WordPuzzleService : IWordPuzzleService
    {
        public List<string> GetWords(string startWord, string endWord)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveWords(List<string> words)
        {
            
            if(words.Any(x => x.Length > 4))
            {
                throw new ArgumentException("SaveWords method failed. Invalid argument in the list");
            };
            throw new System.NotImplementedException();
        }
    }
}
