using CalastoneTest;
using CalastoneTest.Filters;
using CalastoneTest.Readers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestProject
{
    [TestFixture]
    public class TextProcessorTests
    {
        private Mock<IReader> _mockFileReader;

        [SetUp]
        public void Setup()
        {
            _mockFileReader = new Mock<IReader>();

            List<string> lines = new List<string>()
            {
                "alice was beginning to get very tired",
                "she had peeped into the book her sister was reading",
                "but it had no pictures or conversations in it"
            };

            _mockFileReader.Setup(r => r.Read()).Returns(lines);
        }

        [Test]
        public void TextProcessor_ApplyFilter_LetterFilter()
        {
            IFilter filter = new LetterFilter('t');
            
            TextProcessor sut = new TextProcessor(_mockFileReader.Object);
            sut.ApplyFilters(filter);

            _mockFileReader.Verify(mock => mock.Read(), Times.Once());
            Assert.That(sut.Output, Is.EqualTo("alice was beginning very she had peeped book her was reading had no or in"));
        }

        [Test]
        public void TextProcessor_ApplyFilter_LengthFilter()
        {
            IFilter filter = new LengthFilter();

            TextProcessor sut = new TextProcessor(_mockFileReader.Object);
            sut.ApplyFilters(filter);

            _mockFileReader.Verify(mock => mock.Read(), Times.Once());
            Assert.That(sut.Output, Is.EqualTo("alice was beginning get very tired she had peeped into the book her sister was reading but had pictures conversations"));
        }

        [Test]
        public void TextProcessor_ApplyFilter_MiddleVowelFilter()
        {
            IFilter filter = new MiddleVowelFilter();

            TextProcessor sut = new TextProcessor(_mockFileReader.Object);
            sut.ApplyFilters(filter);

            _mockFileReader.Verify(mock => mock.Read(), Times.Once());
            Assert.That(sut.Output, Is.EqualTo("beginning to tired she into the sister reading it no or conversations in it"));
        }

        [Test]
        public void TextProcessor_ApplyFilter_Mulitple()
        {
            TextProcessor sut = new TextProcessor(_mockFileReader.Object);
            sut.ApplyFilters(new LetterFilter('t'), new LengthFilter(), new MiddleVowelFilter());

            _mockFileReader.Verify(mock => mock.Read(), Times.Once());
            Assert.That(sut.Output, Is.EqualTo("beginning she reading"));
        }
    }
}