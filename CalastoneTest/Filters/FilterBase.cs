using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalastoneTest.Filters
{
    public abstract class FilterBase
    {
        /// <summary>
        /// Matches a full word between the word boundary which is any number of characters/digits or an apostrophe
        /// </summary>
        private const string WORD_PATTERN = @"\b[0-9A-Za-z']+\b";

        /// <summary>
        /// Matches whitespace of length 2 or greater
        /// </summary>
        private const string LARGE_WHITESPACE_PATTERN = @"\s{2,}";

        /// <summary>
        /// Filter the words out of a given text string
        /// </summary>
        /// <param name="text">text in which to find matches</param>
        /// <param name="criteria">criteria used to filter the matches</param>
        /// <param name="pattern">optional pattern to override the default</param>
        /// <returns>filtered result</returns>
        protected string FilterByCriteria(string text, Func<Match, bool> criteria, string pattern = WORD_PATTERN)
        {
            IEnumerable<Match> matches = text.GetMatches(pattern).Where(criteria);

            return RemoveMatchesAndCleanse(text, matches);
        }

        /// <summary>
        /// Filter the words out of a given text string
        /// </summary>
        /// <param name="text">text in which to find matches</param>
        /// <param name="pattern">optional pattern to override the default</param>
        /// <returns>filtered result</returns>
        protected string Filter(string text, string pattern = WORD_PATTERN)
        {
            IEnumerable<Match> matches = text.GetMatches(pattern);

            return RemoveMatchesAndCleanse(text, matches);
        }

        /// <summary>
        /// Remove characters based on matches
        /// </summary>
        /// <param name="text">text to remove characters from</param>
        /// <param name="matches">matches defining characters to remove</param>
        /// <returns>resultant string</returns>
        private string RemoveMatchesAndCleanse(string text, IEnumerable<Match> matches)
        {
            StringBuilder builder = new StringBuilder(text);

            // remove the matched values by positional index from the text in REVERSE ORDER 
            foreach (Match match in matches.Reverse())
            {
                builder.Remove(match.Index, match.Length);
            }

            // replace out extra whitespace left by accumulating gaps between remove words
            return Regex.Replace(builder.ToString(), LARGE_WHITESPACE_PATTERN, " ").Trim();
        }
    }
}