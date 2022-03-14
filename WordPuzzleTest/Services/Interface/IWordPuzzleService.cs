using WordPuzzle.Domain.Entities;

namespace WordPuzzle.Services.Interface
{
    public interface IWordPuzzleService
    {
        public Word GetWords(Word word);
        public bool SaveWords(Word word);
    }
}
