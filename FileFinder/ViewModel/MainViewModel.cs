using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using FileFinder.Service;
using ReactiveUI;


namespace FileFinder.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        private readonly IDirectoryFinderService _directoryFinder;
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

        ObservableCollection<DirectoryLineItem> _matchingDirectories;

        public ObservableCollection<DirectoryLineItem> MatchingDirectories
        {
            get => _matchingDirectories;
            set => this.RaiseAndSetIfChanged(ref _matchingDirectories, value);
        }

        string _directorynamePattern;

        public string DirectorynamePattern
        {
            get => _directorynamePattern;
            set
            {
                this.RaiseAndSetIfChanged(ref _directorynamePattern, value);
                FindDirectories.Execute(null);
            }
        }

        string _directoryIgnorePattern;

        public string DirectoryIgnorePattern
        {
            get => _directoryIgnorePattern;
            set
            {
                this.RaiseAndSetIfChanged(ref _directoryIgnorePattern, value);
                FindDirectories?.Execute(null);
            }
        }

        public MainViewModel(IFileFinderService finderService, IDirectoryFinderService directoryFinder)
        {
            _directoryFinder = directoryFinder;
            FinderService = finderService;
            DirectoryIgnorePattern = "\\.vs|\\.svn|\\.git|bin|obj";

            MatchingDirectories = new ObservableCollection<DirectoryLineItem>();

            FindFiles = ReactiveCommand.Create(async () =>
            {
                string result = "";
                //MatchingDirectories.Add(new DirectoryLineItem() {Name = Guid.NewGuid().ToString(), NumberOfFiles = 99});
                await Observable.Start(() =>
                {
                    try
                    {
                        result = FinderService.FindByRegex(Folder, FilenamePattern, CaseSensitive);
                    }
                    catch (Exception ex)
                    {
                        result = ex.ToString();
                    }
                });
                MatchingFiles = result;
            });

            FindDirectories = ReactiveCommand.Create(async () =>
            {
                IEnumerable<DirectoryLineItem> result = null;
                string error = "";
                await Observable.Start(() =>
                {
                    try
                    {
                        result = _directoryFinder.FindAllRecursive(DirectorynamePattern, DirectoryIgnorePattern);
                    }
                    catch (Exception ex)
                    {
                        error = ex.ToString();
                    }
                });
                MatchingDirectories.Clear();
                result.ToList().ForEach( d => MatchingDirectories.Add(d));
                MatchingFiles = error;
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
                FindFiles.Execute(null);
            }
        }

        public string MatchingFiles
        {
            get => _matchingFiles;
            set => this.RaiseAndSetIfChanged(ref _matchingFiles, value);
        }

        public ICommand FindFiles { get; }
        public ICommand FindDirectories{ get; }
    }
}
