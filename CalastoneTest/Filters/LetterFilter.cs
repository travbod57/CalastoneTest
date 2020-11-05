namespace CalastoneTest.Filters
{
    public class LetterFilter : FilterBase, IFilter
    {
        /// <summary>
        /// Matches a full word containing a specific letter (range of upper or lower) between the word boundary which is a range of any number of characters/digits or an apostrophe
        /// </summary>
        private readonly string _wordContainingLetterPattern;
        
        public LetterFilter(char letter)
        {
            _wordContainingLetterPattern = $@"\b[a-zA-Z']*[{ char.ToLower(letter) }{ char.ToUpper(letter) }][a-zA-Z']*\b";
        }

        public string Apply(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            return Filter(text, _wordContainingLetterPattern);
        }
    }
}