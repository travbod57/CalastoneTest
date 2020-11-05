using System.Text.RegularExpressions;

namespace System
{
    public static class Extensions
    {
        public static MatchCollection GetMatches(this string input, string pattern)
        {
            return Regex.Matches(input, pattern);
        }
    }
}