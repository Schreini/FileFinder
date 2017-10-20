using System;
using System.IO.Abstractions;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using FileFinder.Service.Implementation;
using FileFinder.ViewModel;
using System.Windows.Controls;
using DevExpress.XtraEditors;
using ReactiveUI;

namespace FileFinder.View
{
    public partial class MainView : Form, IViewFor<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
            CreateAndBindViewModel();
        }

        private void CreateAndBindViewModel()
        {
            var t = new TextEdit();
            VM = new MainViewModel(new FileFinderService(new FileSystem()), new DirectoryFinderService(new FileSystem()));
            this.Bind(VM, vm => vm.Folder, v => v.TxtDirectoryname.Text, TxtDirectoryname.LostFocusEvent());
            this.Bind(VM, vm => vm.FilenamePattern, v => v.TxtFilename.Text, TxtFilename.KeyUpEvent());
            this.Bind(VM, vm => vm.MatchingFiles, v => v.TxtResult.Text, TxtResult.LostFocusEvent());
            this.Bind(VM, vm => vm.CaseSensitive, v => v.CbxCaseSensitive.Checked, CbxCaseSensitive.CheckedChangedEvent());
            this.BindCommand(VM, vm => vm.FindFiles, c => c.BtnFind, "Click");

            this.Bind(VM, vm => vm.MatchingDirectories, v => v.GrdDirectories.DataSource);
            this.Bind(VM, vm => vm.DirectorynamePattern, v => v.TxtDirectoryname.Text, TxtDirectoryname.KeyUpEvent());
            this.Bind(VM, vm => vm.DirectoryIgnorePattern, v => v.TxtIgnorePattern.Text, TxtIgnorePattern.KeyUpEvent());
        }

        private MainViewModel VM { get; set; }

        object IViewFor.ViewModel
        {
            get => VM;
            set => VM = (MainViewModel)value;
        }

        MainViewModel IViewFor<MainViewModel>.ViewModel
        {
            get => VM;
            set => VM = value;
        }
    }

    public class EditTextObservable : IObservable<TextEdit>
    {
        private readonly TextEdit _txtFolder;

        public EditTextObservable(TextEdit txtFolder)
        {
            _txtFolder = txtFolder;
            _txtFolder.LostFocus += _txtFolder_LostFocus;
        }

        private void _txtFolder_LostFocus(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(IObserver<TextEdit> observer)
        {
            return null;
        }
    }

    public static class TextEditEvents
    {
        public static IObservable<EventPattern<object>> LostFocusEvent(this TextEdit editText)
        {
            return Observable.FromEventPattern(editText, "LostFocus");
        }

        public static IObservable<EventPattern<object>> KeyUpEvent(this TextEdit editText)
        {
            return Observable.FromEventPattern(editText, "KeyUp");
        }
        public static IObservable<EventPattern<object>> CheckedChangedEvent(this CheckEdit checkEdit)
        {
            return Observable.FromEventPattern(checkEdit, "CheckedChanged");
        }

    }
}

