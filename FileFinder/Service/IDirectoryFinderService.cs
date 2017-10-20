using System.Collections.Generic;

namespace FileFinder.Service
{
    public interface IDirectoryFinderService
    {
        IEnumerable<DirectoryLineItem> FindAllRecursive(string rootDirectory);
        IEnumerable<DirectoryLineItem> FindAllRecursive(string rootDirectory, string directoryIgnorePattern);
    }
}
