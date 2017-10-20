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
        string FindByRegex(IEnumerable<DirectoryLineItem> directories, string filenamePattern, bool caseSensitive);
    }

    public class DirectoryLineItem
    {
        public int NumberOfFiles { private get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
