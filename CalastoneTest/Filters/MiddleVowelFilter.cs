using System.Linq;
using System.Text.RegularExpressions;

namespace CalastoneTest.Filters
{
    public class MiddleVowelFilter : FilterBase, IFilter
    {
        private readonly char[] _vowels;

        public MiddleVowelFilter()
        {
            // sorry 'y' you are not a vowel in my eyes
            _vowels = new char[10] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        }

        public string Apply(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            return FilterByCriteria(text, FilterByVowelCriteria);
        }

        /// <summary>
        /// Returns true if the matched value's central letter(s) is/are vowel(s)
        /// </summary>
        /// <param name="match">Match based on the Regex</param>
        /// <returns>Outcome of the filter</returns>
        private bool FilterByVowelCriteria(Match match)
        {
            string word = match.Value;
            bool oddCharacterCount = word.Length % 2 != 0;

            // odd number of characters must have definite a middle letter
            if (word.Length >= 3 && oddCharacterCount)
            {
                if (char.TryParse(word.Substring(word.Length / 2, 1), out char middleLetter))
                {
                    if (_vowels.Any(v => Equals(v, middleLetter)))
                    {
                        return true;
                    }
                }
            }
            // even number of characters must have two middle letters
            else if (word.Length >= 4 && !oddCharacterCount)
            {
                string middleLetters = word.Substring((word.Length / 2) - 1, 2);

                // are eitehr of the middle letters within the array of defined vowels
                if (_vowels.Intersect(middleLetters.ToCharArray()).Count() > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}