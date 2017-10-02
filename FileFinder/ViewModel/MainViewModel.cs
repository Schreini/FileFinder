using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FileFinder.Service;
using ReactiveUI;

namespace FileFinder.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        private string _matchingFiles;
        private string _filenamePattern = "jaja";
        private string _folder = "c:\\";
        public IFileFinderService FinderService { get; }

        public MainViewModel(IFileFinderService finderService)
        {
            FinderService = finderService;
        }

        public string Folder
        {
            get { return _folder; }
            set { this.RaiseAndSetIfChanged(ref _folder, value); }
        }

        public string FilenamePattern
        {
            get { return _filenamePattern; }
            set
            {
                this.RaiseAndSetIfChanged(ref _filenamePattern, value);
                Find.Execute(null);
            }
        }

        public string MatchingFiles
        {
            get { return _matchingFiles; }
            set { this.RaiseAndSetIfChanged(ref _matchingFiles, value); }
        }

        public ICommand Find =>
            ReactiveCommand.Create(() =>
            {
                try
                {
                    MatchingFiles = FinderService.FindByRegex(Folder, FilenamePattern);
                }
                catch (Exception e)
                {
                    MatchingFiles = e.ToString();
                }
            });
    }
}
