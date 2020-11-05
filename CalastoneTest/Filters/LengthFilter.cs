using System.Text.RegularExpressions;

namespace CalastoneTest.Filters
{
    public class LengthFilter : FilterBase, IFilter
    {
        private readonly int _minimumLength;

        public LengthFilter(int minimumLength = 3)
        {
            _minimumLength = minimumLength;
        }

        public string Apply(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            return FilterByCriteria(text, FilterByLength);
        }

        /// <summary>
        /// Returns true if the matched value's length is less than the minimum length
        /// </summary>
        /// <param name="match">Match based on the Regex</param>
        /// <returns>Outcome of the filter</returns>
        private bool FilterByLength(Match match)
        {
            string word = match.Value;

            return word.Length < _minimumLength;
        }
    }
}