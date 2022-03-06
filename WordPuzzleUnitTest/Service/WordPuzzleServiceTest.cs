using WordPuzzle.Service.Interface;
using WordPuzzleUnitTest.Configuration;
using Xunit;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;
using System;

namespace WordPuzzleUnitTest.Service
{
    public class WordPuzzleServiceTest
    {
        private readonly IWordPuzzleService _wordPuzzleService;

        public WordPuzzleServiceTest()
        {
            _wordPuzzleService = ConfigureTest.GetService();   
        }

        [Fact(DisplayName = "GetWordsWithSuccess")]
        public void GetWordsWithSuccess()
        {
            var starWord = "same";
            var endWord = "cost";

            var result = _wordPuzzleService.GetWords(starWord, endWord);

            result.Should().HaveCount(5);
            result.Should().Contain("cast");
        }

        [Fact(DisplayName = "GetWordsInvalidStartWord")]
        public void GetWordsInvalidStartWord()
        {
            var starWord = "correct";
            var endWord = "cost";
            var resultErrorMessage = "Start word should be 4 characters long";

            var result = _wordPuzzleService.GetWords(starWord, endWord);

            result.Should().HaveCount(1);
            result.First().Should().BeEquivalentTo(resultErrorMessage);
        }

        [Fact(DisplayName = "GetWordsInvalidEndWord")]
        public void GetWordsInvalidEndWord()
        {
            var starWord = "same";
            var endWord = "cotoneaster";
            var resultErrorMessage = "End word should be 4 characters long";

            var result = _wordPuzzleService.GetWords(starWord, endWord);

            result.Should().HaveCount(1);
            result.First().Should().BeEquivalentTo(resultErrorMessage);
        }

        [Fact(DisplayName = "GetWordsInvalidStartEndWords")]
        public void GetWordsInvalidStartEndWords()
        {
            var starWord = "cosmopolitan";
            var endWord = "cotoneaster";
            var resultErrorMessage = "Start and end words should be 4 characters long";

            var result = _wordPuzzleService.GetWords(starWord, endWord);

            result.Should().HaveCount(1);
            result.First().Should().BeEquivalentTo(resultErrorMessage);
        }

        [Fact(DisplayName = "SaveWordsFailedArgumentException")]
        public void SaveWordsFailedArgumentException()
        {
            var words = new List<string>() { "same", "cosine", "case", "cast", "cost" };
            Assert.Throws<ArgumentException>(() => _wordPuzzleService.SaveWords(words));            
        }

        [Fact(DisplayName = "SaveWordsWithSuccess")]
        public void SaveWordsWithSuccess()
        {
            var words = new List<string>() { "same", "came", "case", "cast", "cost" };

            var result = _wordPuzzleService.SaveWords(words);            
            result.Should().BeTrue();            
        }
    }
}
