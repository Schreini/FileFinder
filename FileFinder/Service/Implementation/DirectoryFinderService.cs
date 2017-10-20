using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileFinder.Service.Implementation
{
    public class DirectoryFinderService : IDirectoryFinderService
    {
        private readonly FileSystem _fileSystem;

        public DirectoryFinderService(FileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public IEnumerable<DirectoryLineItem> FindAllRecursive(string rootDirectory)
        {
            return FindAllRecursive(rootDirectory, "");
        }

        public IEnumerable<DirectoryLineItem> FindAllRecursive(string rootDirectory, string directoryIgnorePattern)
        {
            return GetDirectoryList(rootDirectory, directoryIgnorePattern);
        }

        private IEnumerable<DirectoryLineItem> GetDirectoryList(string path, string ignorePattern)
        {
            List<DirectoryLineItem> result = new List<DirectoryLineItem>();
            try
            {
                var allDirectories = _fileSystem.Directory.EnumerateDirectories(path).ToList();
                if (ignorePattern != "")
                {
                    var regex = new Regex(ignorePattern);
                    allDirectories.RemoveAll(d => regex.IsMatch(d));
                }
                result.AddRange(allDirectories.Select(d => new DirectoryLineItem() { Name = d }));
                allDirectories.ForEach(d => result.AddRange(GetDirectoryList(d, ignorePattern)));
            }
            catch
            {
                result.Add(new DirectoryLineItem() {Name= path, NumberOfFiles = -1});
            }

            return result;
        }
    }
}