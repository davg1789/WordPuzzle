using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WordPuzzle.Domain.Entities;
using WordPuzzle.Extensions;
using WordPuzzle.Repositories.Interface;

namespace WordPuzzle.Repositories.Implementaiton
{
    public class WordPuzzleRepository : IWordPuzzleRepository
    {
        public Word GetWords(Word word)
        {            
            StreamReader sr = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/words-english/words-english.txt");
            var lines = new List<string>();
            var line = sr.ReadLine();

            while (line != null)
            {
                lines.Add(line);
                line = sr.ReadLine();
            }

            var words = lines.Filter();

            words.Sort();
            
            word.Words = GetAllWords(words, word.StartWord, word.EndWord);
            word.IsValid = word.Words == null ? false : true;
            return word;
        }

        public bool SaveWords(Word word)
        {
            try
            {                
                File.WriteAllLines($"{Directory.GetCurrentDirectory()}/words-english/final-result.txt", word.Words);
                return true;
            }
            catch (Exception)
            {
                return false;   
            }             
        }

        private List<string> GetAllWords(List<string> words, string startWord, string endWord, List<string> wordsFiltered = null, bool wordFound = false, int count = 0, int position = 0)
        {
            ConfigureBeforeSeek(ref startWord, ref wordsFiltered, ref wordFound, ref count, ref position);

            if (startWord == endWord)
                return wordsFiltered;

            if (count == 4 && wordFound == false)
            {
                return null;
            }

            var filterWord = "";

            filterWord = GetWordToSeek(startWord, endWord, position, filterWord);

            var newWord = words.Where(x => x == filterWord).FirstOrDefault();

            ConfigureAfterSeek(ref startWord, ref newWord, ref wordFound, ref count, ref position);

            wordsFiltered = GetAllWords(words, newWord, endWord, wordsFiltered, wordFound, count, position);
            return wordsFiltered;
        }

        private void ConfigureAfterSeek(ref string startWord, ref string newWord, ref bool wordFound, ref int count, ref int position)
        {
            if (string.IsNullOrWhiteSpace(newWord))
            {
                wordFound = false;
                newWord = startWord;
            }
            else
            {
                wordFound = true;
            }

            count++;
            position++;
        }

        private void ConfigureBeforeSeek(ref string startWord, ref List<string> wordsFiltered, ref bool wordFound, ref int count, ref int position)
        {
            if (wordFound)
            {
                wordsFiltered.Add(startWord);
                count = 0;
                wordFound = false;
            }
            else
            {
                if (wordsFiltered != null && wordsFiltered.Count > 1)
                {
                    wordsFiltered.RemoveAt(wordsFiltered.Count - 1);
                    startWord = wordsFiltered.Last();
                    position--;
                }
            }

            if (wordsFiltered == null)
            {
                wordsFiltered = new List<string>();
                wordsFiltered.Add(startWord);
            }

            if (position == 4)
                position = 0;
        }

        private string GetWordToSeek(string startWord, string endWord, int position, string filterWord)
        {
            for (int i = position; i < 4; i++)
            {
                if (startWord.Substring(i, 1) == endWord.Substring(i, 1))
                {
                    continue;
                }

                if (i == 0)
                {
                    filterWord = endWord.Substring(i, 1) + startWord.Substring(1);
                }
                else
                {
                    if (i == 3)
                    {
                        filterWord = startWord.Substring(0, 3) + endWord.Substring(i, 1);
                    }
                    else
                    {
                        filterWord = startWord.Substring(0, i) + endWord.Substring(i, 1) + startWord.Substring(i + 1);
                    }
                }
                break;
            }

            return filterWord;
        }
    }
}
