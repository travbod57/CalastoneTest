using CalastoneTest.Filters;
using CalastoneTest.Readers;
using System;
using System.Diagnostics;
using System.IO;

namespace CalastoneTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // File copied as content to bin so project will run the sample text
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleText.txt");

            Stopwatch stopWatch = Stopwatch.StartNew();

            // IFileSystem is an abstraction to allow unit testing for the FileNotFoundException
            IFileSystem fileSystem = new FileSystem(filePath);

            TextProcessor processor = new TextProcessor(new TextFileReader(fileSystem));
            processor.ApplyFilters(new LengthFilter(), new MiddleVowelFilter(), new LetterFilter('t'));

            stopWatch.Stop();

            // Reporting

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Processed in { stopWatch.ElapsedMilliseconds }ms");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("======");
            Console.WriteLine("Output");
            Console.WriteLine("======");
            Console.WriteLine();

            Console.WriteLine(processor.Output);            

            Console.ReadLine();
        }
    }
}
