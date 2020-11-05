using CalastoneTest.Filters;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class MiddleVowelFilterTests
    {
        [TestCase("a in to", ExpectedResult = "a in to", TestName = "MiddleVowelFilter_Filter_WordsShorterThanThreeCharacters_Keep")]
        [TestCase("ate ore ace whether world ought", ExpectedResult = "ate ore ace whether world ought", TestName = "MiddleVowelFilter_Filter_OddThreeOrGreaterCharacterLengthWords_Keep")]
        [TestCase("par her hit hot hut chain stern third stood churn", ExpectedResult = "", TestName = "MiddleVowelFilter_Filter_OddThreeOrGreaterCharacterLengthWordsLowerCase_Remove")]
        [TestCase("PAR HER HIT HOT HUT CHAIN STERN THIRD STOOD CHURN", ExpectedResult = "", TestName = "MiddleVowelFilter_Filter_OddThreeOrGreaterCharacterLengthWordsUpperCase_Remove")]
        [TestCase("elks alps ashy ousted oathes earths", ExpectedResult = "elks alps ashy ousted oathes earths", TestName = "MiddleVowelFilter_Filter_EvenFourOrGreaterCharacterLengthWords_Keep")]
        [TestCase("race tree rice bore hurt charts sheets shirts shorts church", ExpectedResult = "", TestName = "MiddleVowelFilter_Filter_EvenFourOrGreaterCharacterLengthWordsLowerCase_Remove")]
        [TestCase("RACE TREE RICE BORE HURT CHARTS SHEETS SHIRTS SHORTS CHURCH", ExpectedResult = "", TestName = "MiddleVowelFilter_Filter_EvenFourOrGreaterCharacterLengthWordsUpperCase_Remove")]
        [TestCase("Alice was beginning to get very tired of sitting by her sister on the bank", ExpectedResult = "beginning to tired of sitting by sister on the", TestName = "MiddleVowelFilter_Filter_MixedSentenceLowerCase")]
        [TestCase("ALICE WAS BEGINNING TO GET VERY TIRED OF SITTING BY HER SISTER ON THE BANK", ExpectedResult = "BEGINNING TO TIRED OF SITTING BY SISTER ON THE", TestName = "MiddleVowelFilter_Filter_MixedSentenceUpperCase")]
        public string MiddleVowelFilter_Filter(string text)
        {
            IFilter sut = new MiddleVowelFilter();

            string output = sut.Apply(text);

            return output;
        }

        [TestCase("", ExpectedResult = "", TestName = "MiddleVowelFilter_Filter_EmptyString")]
        [TestCase(null, ExpectedResult = "", TestName = "MiddleVowelFilter_Filter_Null")]
        public string LengthFilter_Filter(string text)
        {
            IFilter sut = new MiddleVowelFilter();

            string output = sut.Apply(text);

            return output;
        }
    }
}