using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FileFinder.Service.Implementation
{
    public class FileFinderService : IFileFinderService
    {
        private readonly FileSystem _fileSystem;
        private readonly IDictionary<string, IList<string>> _cache = new Dictionary<string, IList<string>>();

        public FileFinderService(FileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string FindByRegex(string folder, string filenamePattern, bool caseSensitive)
        {
            StringBuilder result = new StringBuilder();
            var list = GetFileList(folder);

            var regex = BuildRegex(filenamePattern, caseSensitive);
            foreach (var file in list)
            {
                if (regex.IsMatch(file))
                {
                    result.AppendLine(file);
                }
            }
            return result.ToString();
        }

        public string FindByRegex(IEnumerable<DirectoryLineItem> directories, string filenamePattern, bool caseSensitive)
        {
            StringBuilder result = new StringBuilder();
            foreach (var dir in directories)
            {
                result.Append(FindByRegex(dir.Name, filenamePattern, caseSensitive));
            }
            return result.ToString();
        }

        public IEnumerable<DirectoryLineItem> FindDirectoriesByRegex(string directory, string pattern, bool caseSensitive)
        {
            IList<DirectoryLineItem> result = new List<DirectoryLineItem>();
            var list = GetDirectoryList(directory);

            foreach (var dir in list)
            {
                result.Add(new DirectoryLineItem() {Name = dir, NumberOfFiles = 0});
            }
            return result;
        }

        private IEnumerable<string> GetDirectoryList(string directory)
        {
            List<string> dirs = _fileSystem.Directory.EnumerateDirectories(directory).ToList();
            foreach (var dir in dirs)
            {
                dirs.AddRange(GetDirectoryList(dir));
            }
            return dirs;
        }

        private static Regex BuildRegex(string filenamePattern, bool caseSensitive)
        {
            var regexOptions = caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
            return new Regex(filenamePattern, regexOptions);
        }

        private IList<string> GetFileList(string folder)
        {
            if (!_cache.ContainsKey(folder))
            {
                AddFileListToCache(folder);
            }
            IList<string> list = _cache[folder];
            return list;
        }

        private void AddFileListToCache(string folder)
        {
            List<string> files = _fileSystem.Directory.EnumerateFiles(folder).ToList();
            _cache.Add(folder, files);
        }

        //private List<string> TraverseFileSystem(string folder)
        //{
        //    List<string> files = _fileSystem.Directory.EnumerateFiles(folder).ToList();
        //    foreach (var dir in _fileSystem.Directory.EnumerateDirectories(folder).ToList())
        //    {
        //        files.AddRange(TraverseFileSystem(dir));
        //    }
        //    return files;
        //}
    }
}
