using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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
            int count = 0;

            var regex = BuildRegex(filenamePattern, caseSensitive);
            foreach (var file in list)
            {
                if (regex.IsMatch(file))
                {
                    result.AppendLine(file);
                    count++;
                }
            }
            result.AppendLine($"Found {count} files.");
            return result.ToString();
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
            List<string> files = TraverseFileSystem(folder);
            _cache.Add(folder, files);
        }

        private List<string> TraverseFileSystem(string folder)
        {
            List<string> files = _fileSystem.Directory.EnumerateFiles(folder).ToList();
            foreach (var dir in _fileSystem.Directory.EnumerateDirectories(folder).ToList())
            {
                files.AddRange(TraverseFileSystem(dir));
            }
            return files;
        }
    }
}
