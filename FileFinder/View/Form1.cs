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
    public partial class MainForm : Form, IViewFor<MainViewModel>
    {
        public MainForm()
        {
            InitializeComponent();
            CreateAndBindViewModel();
        }

        private void CreateAndBindViewModel()
        {
            var t = new TextEdit();
            VM = new MainViewModel(new FileFinderService(new FileSystem()));
            this.Bind(VM, vm => vm.Folder, v => v.TxtFolder.Text, TxtFolder.LostFocusEvent());
            this.WhenAnyValue(x=>x.TxtFilename.Text).BindTo(VM, vm => vm.FilenamePattern);
            this.Bind(VM, vm => vm.MatchingFiles, v => v.TxtResult.Text, TxtResult.LostFocusEvent());
            this.BindCommand(VM, vm => vm.Find, c => c.BtnFind, "Click");
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

    }
}

