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
        [Fact]
        public void GetDirectoryReturnsOwnDirectory()
        {
            var somedir = "c:\\SomeDir";
            var target = new DirectoryFinderService(new MockFileSystem(new Dictionary<string, MockFileData>()
            {
                { somedir, new MockDirectoryData()},
                { "c:\\SomeDir\\someFile.txt", new MockFileData("some content")}
            }));

            var actual = target.FindAllRecursive(somedir);

            Assert.Single(actual);
            Assert.Equal(somedir, actual.Single().Name);
        }

        [Theory]
        [InlineData(@"c:\")]
        [InlineData(@"c:\HalloWelt")]
        [InlineData(@"c:\HalloWelt\jaja")]
        [InlineData(@"c:\Mimi")]
        public void TheoryMethodName(string directory)
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
