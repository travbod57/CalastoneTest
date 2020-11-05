using CalastoneTest.Filters;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class LengthFilterTests
    {
        [TestCase(3, ExpectedResult = "Alice was beginning get very tired sitting her sister the bank")]
        [TestCase(4, ExpectedResult = "Alice beginning very tired sitting sister bank")]
        public string LengthFilter_Filter(int length)
        {
            IFilter sut = new LengthFilter(length);

            string output = sut.Apply("Alice was beginning to get very tired of sitting by her sister on the bank");

            return output;
        }

        [TestCase("", ExpectedResult = "", TestName = "LengthFilter_Filter_EmptyString")]
        [TestCase(null, ExpectedResult = "", TestName = "LengthFilter_Filter_Null")]
        public string LengthFilter_Filter(string text)
        {
            IFilter sut = new LengthFilter();

            string output = sut.Apply(text);

            return output;
        }

        [Test]
        public void LengthFilter_Filter_Whitespace()
        {
            IFilter sut = new LengthFilter();

            string output = sut.Apply("hello   this  has much  of   whitespace");

            Assert.That(output, Is.EqualTo("hello this has much whitespace"));
        }

        [Test]
        public void LengthFilter_Filter_Punctuation()
        {
            IFilter sut = new LengthFilter(6);

            string output = sut.Apply("This isn't what I was going to verbalise.It therefore doesn't matter.It's the thought that counts surely?");

            Assert.That(output, Is.EqualTo("verbalise. therefore doesn't matter. thought counts surely?"));
        }
    }
}