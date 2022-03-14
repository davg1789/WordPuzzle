using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using WordPuzzle.Domain.Entities;
using WordPuzzle.Repositories.Interface;
using WordPuzzle.Services.Implementaiton;
using WordPuzzle.Services.Interface;
using Xunit;

namespace WordPuzzleTest.Service.UnitTest
{
    public class WordPuzzleServiceUnitTest
    {
        private readonly IWordPuzzleService _wordPuzzleService;
        private readonly Mock<IWordPuzzleRepository> wordPuzzleRepositoryMock;

        public WordPuzzleServiceUnitTest()
        {
            wordPuzzleRepositoryMock = new Mock<IWordPuzzleRepository>();
            _wordPuzzleService = new WordPuzzleService(wordPuzzleRepositoryMock.Object);
        }

        [Fact(DisplayName = "SaveWordsFailedArgumentException")]
        public void SaveWordsFailedArgumentException()
        {
            var word = new Word();
            word.Words = new List<string>() { "same", "cosine", "case", "cast", "cost" };
            Assert.Throws<ArgumentException>(() => _wordPuzzleService.SaveWords(word));
        }

        [Fact(DisplayName = "SaveWordsWithSuccess")]
        public void SaveWordsWithSuccess()
        {
            var word = new Word();
            word.Words = new List<string>() { "same", "came", "case", "cast", "cost" };

            wordPuzzleRepositoryMock.Setup(x => x.SaveWords(It.IsAny<Word>())).Returns(true);
            var result = _wordPuzzleService.SaveWords(word);
            result.Should().BeTrue();
        }
    }
}
