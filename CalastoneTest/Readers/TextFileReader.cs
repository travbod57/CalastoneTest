using System;
using System.Collections.Generic;
using System.IO;

namespace CalastoneTest.Readers
{
    public class TextFileReader : IReader
    {
        private readonly string _filePath;

        public TextFileReader(IFileSystem fileSystem)
        {
            if (string.IsNullOrWhiteSpace(fileSystem.FilePath))
            {
                throw new ArgumentNullException(nameof(fileSystem.FilePath));
            }

            if (!File.Exists(fileSystem.FilePath))
            {
                throw new FileNotFoundException(nameof(fileSystem.FilePath));
            }

            _filePath = fileSystem.FilePath;
        }

        public IEnumerable<string> Read()
        {
            // 'ReadLines' gets one line at a time requiring only one line to be read into memory at any given time
            foreach (string line in File.ReadLines(_filePath))
            {
                yield return line;
            }
        }
    }
}