using FluentAssertions;
using System.Linq;
using WordPuzzle.Domain.Entities;
using WordPuzzle.Services.Interface;
using WordPuzzleUnitTest.Configuration;
using Xunit;

namespace WordPuzzleUnitTest.Service.IntegrationTest
{
    public class WordPuzzleServiceIntegrationTest
    {
        private readonly IWordPuzzleService _wordPuzzleService;        

        public WordPuzzleServiceIntegrationTest()
        {
            _wordPuzzleService = ConfigureTest.GetService();            
        }
        
        [Theory(DisplayName = "GetWordsWithSuccess")]
        [InlineData("spin", "spit", "spot")]
        [InlineData("same", "came", "case", "cast", "cost")]
        [InlineData("risk", "rink", "ring")]

        public void GetWordsWithSuccess(params string[] wordsExpected)
        {
            var word = new Word();
            word.StartWord = wordsExpected.First();
            word.EndWord = wordsExpected.Last(); 

            var result = _wordPuzzleService.GetWords(word);

            result.Words.Should().HaveCount(wordsExpected.Length);
            result.Words.Should().BeEquivalentTo(wordsExpected);
            result.IsValid.Should().BeTrue();
        }

        [Fact(DisplayName = "GetWordsInvalidStartWord")]
        public void GetWordsInvalidStartWord()
        {
            var word = new Word();
            word.StartWord = "correct";
            word.EndWord = "cost";
            
            var resultErrorMessage = "Start word should be 4 characters long";

            var result = _wordPuzzleService.GetWords(word);

            result.Words.Should().HaveCount(1);
            result.Words.First().Should().BeEquivalentTo(resultErrorMessage);
            result.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "GetWordsInvalidEndWord")]
        public void GetWordsInvalidEndWord()
        {
            var word = new Word();
            word.StartWord = "same";
            word.EndWord = "cotoneaster";
            
            var resultErrorMessage = "End word should be 4 characters long";

            var result = _wordPuzzleService.GetWords(word);

            result.Words.Should().HaveCount(1);
            result.Words.First().Should().BeEquivalentTo(resultErrorMessage);
            result.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "GetWordsInvalidStartEndWords")]
        public void GetWordsInvalidStartEndWords()
        {
            var word = new Word();
            word.StartWord = "cosmopolitan";
            word.EndWord = "cotoneaster";
            
            var resultStartErrorMessage = "Start word should be 4 characters long";
            var resultEndErrorMessage = "End word should be 4 characters long";

            var result = _wordPuzzleService.GetWords(word);

            result.Words.Should().HaveCount(2);
            result.Words.First().Should().BeEquivalentTo(resultStartErrorMessage);
            result.Words.Last().Should().BeEquivalentTo(resultEndErrorMessage);
            result.IsValid.Should().BeFalse();
        }
    }
}
