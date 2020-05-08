using Modelisateur.Model;
using ModelisateurWPF.Collections;
using ModelisateurWPF.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ModelisateurWPF.ViewModel
{
    class EntiteViewModel : TabViewModel, IViewModel, IDataErrorInfo
    {
        public ICommand AddElementDonneeCommand { get; }
        public ICommand RemoveElementDonneeCommand { get; }

        private Entite _entite;
        public override object Model { get => _entite; }
        public string Name
        {
            get { return _entite.Name; }
            set
            {
                _entite.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ViewModelCollection<ElementDonneeViewModel, ElementDonnee> ElementsDonnees { get; }

        private ElementDonneeViewModel _selectedElementDonnee;
        public ElementDonneeViewModel SelectedElementDonnee
        {
            get { return _selectedElementDonnee; }
            set
            {
                _selectedElementDonnee = value;
                OnPropertyChanged(nameof(SelectedElementDonnee));
            }
        }

        public string this[string columnName] => throw new System.NotImplementedException();

        public string Error => throw new System.NotImplementedException();

        public EntiteViewModel() : this(new Entite()) { }

        public EntiteViewModel(Entite entite)
        {
            _entite = entite;
            AddElementDonneeCommand = new RelayCommand(o => this.AddElementDonnee());
            RemoveElementDonneeCommand = new RelayCommand(o => this.RemoveElementDonnee(o));

            ElementsDonnees = new ViewModelCollection<ElementDonneeViewModel, ElementDonnee>(_entite.ElementsDonnees);
            foreach (var model in _entite.ElementsDonnees)
            {
                var vm = new ElementDonneeViewModel(model);
                vm.PropertyChanged += ElementDonneeVm_PropertyChanged;
                ElementsDonnees.Load(vm);
            }
        }

        private void ElementDonneeVm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("SourceCode");
        }

        private void AddElementDonnee()
        {
            var vm = new ElementDonneeViewModel();
            vm.PropertyChanged += ElementDonneeVm_PropertyChanged;
            ElementsDonnees.Add(vm);
            OnPropertyChanged("SourceCode");
        }

        private void RemoveElementDonnee(object param)
        {
            var elementDonnee = param as ElementDonneeViewModel;
            if (elementDonnee != null && ElementsDonnees.Contains(elementDonnee))
                ElementsDonnees.Remove(elementDonnee);
            OnPropertyChanged("SourceCode");
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}