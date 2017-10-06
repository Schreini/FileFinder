using System.Reactive.Linq;
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

        bool _caseSensitive;

        public bool CaseSensitive
        {
            get => _caseSensitive;
            set => this.RaiseAndSetIfChanged(ref _caseSensitive, value);
        }

        public MainViewModel(IFileFinderService finderService)
        {
            FinderService = finderService;
            Find = ReactiveCommand.Create(async () =>
            {
                string result = "";
                await Observable.Start(() =>
                {
                    result = FinderService.FindByRegex(Folder, FilenamePattern, CaseSensitive);
                });
                MatchingFiles = result;
            });
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
            get => _matchingFiles;
            set => this.RaiseAndSetIfChanged(ref _matchingFiles, value);
        }

        public ICommand Find { get; }
    }
}
