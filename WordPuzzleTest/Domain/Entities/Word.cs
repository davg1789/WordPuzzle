using System.Collections.Generic;

namespace WordPuzzle.Domain.Entities
{
    public class Word
    {
        public string StartWord { get; set; }
        public string EndWord { get; set; }
        public List<string> Words { get; set; }
        public bool IsValid { get; set; }        
    }
}
