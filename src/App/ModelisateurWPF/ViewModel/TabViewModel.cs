using ModelisateurWPF.ViewModel.Commands;
using System;
using System.Windows.Input;

namespace ModelisateurWPF.ViewModel
{
    abstract class TabViewModel : ViewModelBase, IViewModel
    {
        public ICommand CloseCommand { get; }
        public ICommand SaveCommand { get; }
        public abstract object Model { get; }

        public event EventHandler OnClose;
        public event EventHandler OnSave;
        
        public abstract bool IsValid();

        public TabViewModel() : this(null)
        { }

        public TabViewModel(string displayName)
        {
            DisplayName = displayName;
            CloseCommand = new RelayCommand(o => this.Close());
            SaveCommand = new RelayCommand(o => this.Save(), o => this.IsValid());
        }

        private void Close()
        {
            OnClose?.Invoke(this, new EventArgs());
        }

        private void Save()
        {
            OnSave?.Invoke(this, new EventArgs());
        }
    }
}