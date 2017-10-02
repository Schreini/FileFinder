using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder.Service
{
    public interface IFileFinderService
    {
        string FindByRegex(string folder, string filenamePattern);
    }
}
