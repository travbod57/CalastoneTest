using CalastoneTest;
using CalastoneTest.Readers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestProject
{
    [TestFixture]
    public class TextFileReaderTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void TextFileReader_ArgumentNullException(string filePath)
        {
            Mock<IFileSystem> fileSystem = new Mock<IFileSystem>();
            fileSystem.Setup(fs => fs.FilePath).Returns(filePath);

            Assert.That(() => new TextFileReader(fileSystem.Object), Throws.ArgumentNullException.With.Property("Message").Contains("FilePath"));
        }

        [Test]
        public void TextFileReader_FileNotFoundException()
        {
            Mock<IFileSystem> fileSystem = new Mock<IFileSystem>();
            fileSystem.Setup(fs => fs.FilePath).Returns(@"C:\temp\sample.txt");
            fileSystem.Setup(fs => fs.FileExists()).Returns(false);

            Assert.That(() => new TextFileReader(fileSystem.Object), Throws.TypeOf<FileNotFoundException>().With.Property("Message").Contains("FilePath"));
        }

        [Test]
        public void TextFileReader_Read()
        {
            List<string> fileLines = new List<string>()
            {
                "This is the first line",
                "This is the second line",
                "This is the third line"
            };

            Mock<IReader> mockFileReader = new Mock<IReader>();
            mockFileReader.Setup(r => r.Read()).Returns(fileLines);

            List<string> lines = mockFileReader.Object.Read().ToList();

            Assert.That(3, Is.EqualTo(lines.Count()));
            Assert.That(lines[0], Is.EqualTo("This is the first line"));
            Assert.That(lines[1], Is.EqualTo("This is the second line"));
            Assert.That(lines[2], Is.EqualTo("This is the third line"));
        }
    }
}