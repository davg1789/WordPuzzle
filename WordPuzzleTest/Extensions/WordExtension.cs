using System.Collections.Generic;
using WordPuzzle.Domain.Entities;

namespace WordPuzzle.Extensions
{
    public static class WordExtension
    {
        public static void ValidateWord(this Word word)
        {
            word.Words = new List<string>();
            if (word.StartWord.Length != 4)
            {                
                word.Words.Add("Start word should be 4 characters long");
            }

            if (word.EndWord.Length != 4)
            {
                word.Words.Add("End word should be 4 characters long");                
            }

            word.IsValid = word.Words.Count > 0 ?  false : true;
        }
    }
}
