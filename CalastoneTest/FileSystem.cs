using System.IO;

namespace CalastoneTest
{
    public class FileSystem : IFileSystem
    {
        public FileSystem(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }

        public bool FileExists()
        {
            return File.Exists(FilePath);
        }
    }

    public interface IFileSystem
    {
        string FilePath { get; }
        bool FileExists();
    }
}