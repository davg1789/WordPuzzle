using System;
using System.Linq;
using WordPuzzle.Domain.Entities;
using WordPuzzle.Extensions;
using WordPuzzle.Repositories.Interface;
using WordPuzzle.Services.Interface;

namespace WordPuzzle.Services.Implementaiton
{
    public class WordPuzzleService : IWordPuzzleService
    {
        private readonly IWordPuzzleRepository _wordPuzzleRepository;

        public WordPuzzleService(IWordPuzzleRepository wordPuzzleRepository)
        {
            _wordPuzzleRepository = wordPuzzleRepository;
        }

        public Word GetWords(Word word)
        {
            word.ValidateWord();
            if (word.IsValid == false)
                return word;

            return _wordPuzzleRepository.GetWords(word);
        }

        public bool SaveWords(Word word)
        {
            
            if(word.Words.Any(x => x.Length > 4))
            {
                throw new ArgumentException("SaveWords method failed. Invalid argument in the list");
            };
            
            return _wordPuzzleRepository.SaveWords(word);
        }       
    }
}
