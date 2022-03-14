using System;
using System.IO;
using WordPuzzle.Configuration;
using WordPuzzle.Domain.Entities;

namespace WordPuzzle
{
    public static class WordPuzzleApp
    {
        public static void Run()
        {
            try
            {
                var quit = "";
                while(quit != "x")
                {
                    var word = new Word();
                    var wordPuzzleService = ConfigureApp.GetWordPuzzleServiceInstance();
                    InitializeWords(word);

                    word = wordPuzzleService.GetWords(word);

                    if (word.IsValid)
                    {
                        var result = wordPuzzleService.SaveWords(word);
                        if (result == false)
                        {
                            Console.WriteLine("Error to save");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($"File saved successfully at {Directory.GetCurrentDirectory()}\\words-english\\final-result.txt!");
                        }
                    }

                    WriteResult(word);
                    quit = GetOptionToQuit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            } 
        }

        private static string GetOptionToQuit()
        {
            string quit;
            Console.WriteLine();
            Console.WriteLine("Enter x to quit or space to continue");
            quit = Console.ReadLine();
            Console.WriteLine();
            return quit;
        }

        private static void WriteResult(Word word)
        {
            Console.WriteLine();
            Console.WriteLine("Result:");
            if (word.Words == null)
            {
                Console.WriteLine("Result not found");
            }
            else
            {
                foreach (var item in word.Words)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void InitializeWords(Word word)
        {
            Console.WriteLine("Enter the start word");
            word.StartWord = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter the end word");
            word.EndWord = Console.ReadLine();
        }
    }
}
