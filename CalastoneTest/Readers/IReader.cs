using System.Collections.Generic;

namespace CalastoneTest.Readers
{
    public interface IReader
    {
        IEnumerable<string> Read();
    }
}