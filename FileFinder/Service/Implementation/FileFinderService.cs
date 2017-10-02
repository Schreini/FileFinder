using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public string FindByRegex(string folder, string filenamePattern)
        {
            StringBuilder result = new StringBuilder();
            var list = GetFileList(folder);
            int count = 0;
            foreach (var file in list)
            {
                var regex = new Regex(filenamePattern);
                if (regex.IsMatch(file))
                {
                    result.AppendLine(file);
                    count++;
                }
            }
            result.AppendLine($"Found {count} files.");
            return result.ToString();
        }

        private IList<string> GetFileList(string folder)
        {
            return _fileSystem.Directory.EnumerateFiles(folder).ToList();
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
    }
}
