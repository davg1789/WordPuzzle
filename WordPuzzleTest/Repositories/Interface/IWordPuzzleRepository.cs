using WordPuzzle.Domain.Entities;

namespace WordPuzzle.Repositories.Interface
{
    public interface IWordPuzzleRepository
    {
        public Word GetWords(Word word);
        public bool SaveWords(Word word);
    }
}
