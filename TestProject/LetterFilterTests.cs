using CalastoneTest.Filters;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class LetterFilterTests
    { 
        [TestCase('t', "alice was beginning to get very tired of sitting by her sister on the bank", ExpectedResult = "alice was beginning very of by her on bank", TestName = "LetterFilter_Filter_LowerCase")]
        [TestCase('T', "ALICE WAS BEGINNING TO GET VERY TIRED OF SITTING BY HER SISTER ON THE BANK", ExpectedResult = "ALICE WAS BEGINNING VERY OF BY HER ON BANK", TestName = "LetterFilter_Filter_UpperCase")]
        [TestCase('t', "It doesn't matter how high, but it's twice as high as that!", ExpectedResult = "how high, as high as !", TestName = "LetterFilter_Filter_Punctuation")]
        public string LetterFilter_Filter(char letter, string text)
        {
            IFilter sut = new LetterFilter(letter);

            string output = sut.Apply(text);

            return output;
        }

        [TestCase("", ExpectedResult = "", TestName = "LetterFilter_Filter_EmptyString")]
        [TestCase(null, ExpectedResult = "", TestName = "LetterFilter_Filter_Null")]
        public string LengthFilter_Filter(string text)
        {
            IFilter sut = new LetterFilter('t');

            string output = sut.Apply(text);

            return output;
        }
    }
}