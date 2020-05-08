using Modelisateur.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ModelisateurWPF.ViewModel
{
    class LiaisonViewModel : ViewModelBase, IViewModel
    {
        public ICommand RemoveCommand { get; }

        private Liaison _liaison;
        public object Model => _liaison;

        public string NameEntite 
        { 
            get { return _liaison.NameEntite; }
            set
            {
                _liaison.NameEntite = value;
                OnPropertyChanged(nameof(NameEntite));
                OnPropertyChanged("SourceCode");
            }
        }

        ObservableCollection<string> ElementsDonnees { get; }

        public LiaisonViewModel(ICommand removeCommand) : this(new Liaison(), removeCommand)
        { }

        public LiaisonViewModel(Liaison liaison, ICommand removeCommand)
        {
            RemoveCommand = removeCommand;
            _liaison = liaison;
            ElementsDonnees = new ObservableCollection<string>(_liaison.ElementsDonnees);
        }
    }
}