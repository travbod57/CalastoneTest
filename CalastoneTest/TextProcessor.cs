using CalastoneTest.Filters;
using CalastoneTest.Readers;
using System.Text;

namespace CalastoneTest
{
    public class TextProcessor
    {
        private readonly IReader _reader;
        
        public TextProcessor(IReader reader)
        {
            _reader = reader;
        }

        public void ApplyFilters(params IFilter[] filters)
        {
            StringBuilder outputBuilder = new StringBuilder();

            // read one file line at a time from a yielded return from the reader
            foreach (string line in _reader.Read())
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string filteredLineResult = line;

                    // apply each filter in turn
                    foreach (IFilter filter in filters)
                    {
                        // reassigning the filtered and reduced output of this iteration to feed into a subsequent iteration
                        filteredLineResult = filter.Apply(filteredLineResult);
                    }

                    outputBuilder.AppendFormat("{0} ", filteredLineResult);
                }
            }

            Output = outputBuilder.ToString().Trim();
        }

        public string Output { get; private set; }
    }
}