using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder.Service
{
    public interface IFileFinderService
    {
        string FindByRegex(string folder, string filenamePattern, bool caseSensitive);
        IEnumerable<DirectoryLineItem> FindDirectoriesByRegex(string directory, string pattern, bool caseSensitive);
    }

    public class DirectoryLineItem
    {
        public int NumberOfFiles { private get; set; }
        public string Name { get; set; }
    }
}
