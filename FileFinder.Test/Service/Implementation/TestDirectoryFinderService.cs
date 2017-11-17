using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FileFinder.Service.Implementation;
using Xunit;
using Xunit.Sdk;

namespace FileFinder.Test.Service.Implementation
{
    public class TestDirectoryFinderService
    {
        [Theory]
        [InlineData(@"c:\HalloWelt\")]
        [InlineData(@"c:\HalloWelt\jaja\")]
        [InlineData(@"c:\Mimi\")]
        public void GetDirectoryReturnsOwnDirectory(string directory)
        {
            var target = new DirectoryFinderService(new MockFileSystem(new Dictionary<string, MockFileData>()
            {
                { directory, new MockDirectoryData()},
            }));

            var actual = target.FindAllRecursive(directory);

            Assert.Single(actual);
            Assert.Equal(directory, actual.Single().Name);
        }
    }
}
