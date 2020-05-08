using Modelisateur.Model;
using Modelisateur.Model.Repositories;
using ModelisateurWPF.Collections;
using ModelisateurWPF.ViewModel.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace ModelisateurWPF.ViewModel
{
    class EmplacementViewModel : TabViewModel, IDataErrorInfo
    {
        private EmplacementRepository _repository;
        private Emplacement _emplacement;

        private EntiteViewModel _selectedEntite;
        public EntiteViewModel SelectedEntite
        {
            get { return _selectedEntite; }
            set
            {
                _selectedEntite = value;
                OnPropertyChanged(nameof(SelectedEntite));
            }
        }

        public string FilePath { get; }

        public string Name
        {
            get { return _emplacement.Name; }
            set
            {
                _emplacement.Name = value;
                OnPropertyChanged(nameof(SourceCode));
                OnPropertyChanged(nameof(Name));
            }
        }

        public ViewModelCollection<EntiteViewModel, Entite> Entites { get; }

        public string SourceCode
        {
            get
            {
                return _emplacement.GetSourceCode();
            }
            set
            {
                _emplacement = _emplacement.SetFromSourceCode(value);
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Entites));
            }
        }

        public ICommand AddEntiteCommand { get; }
        public ICommand RemoveEntiteCommand { get; }

        public string Error => "Invalid value";

        public override object Model => _emplacement;

        public string this[string columnName]
        {
            get
            {
                string validationMessage = null;
                if (columnName == "Name")
                {
                    if (string.IsNullOrWhiteSpace(Name) || Name == "testerror")
                        validationMessage = "testerror";
                }
                return validationMessage;
            }
        }

        public EmplacementViewModel(string displayName, string filePath)
        {
            DisplayName = displayName;
            FilePath = filePath;
            AddEntiteCommand = new RelayCommand(o => this.CreateEntite());
            RemoveEntiteCommand = new RelayCommand(o => this.RemoveEntite(o));
            _repository = new EmplacementRepository(new System.IO.FileInfo(FilePath));
            _emplacement = _repository.Load();

            Entites = new ViewModelCollection<EntiteViewModel, Entite>(_emplacement.Entites);
            foreach (var model in _emplacement.Entites)
            { 
                var vm = new EntiteViewModel(model);
                vm.PropertyChanged += EntiteVm_PropertyChanged;
                Entites.Load(vm);
            }

            OnSave += EmplacementViewModel_OnSave;
        }

        private void EntiteVm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SourceCode));
        }

        private void EmplacementViewModel_OnSave(object sender, System.EventArgs e)
        {
            _repository.Save(_emplacement, false);
        }

        private void CreateEntite()
        {
            var entiteVM = new EntiteViewModel();
            entiteVM.Name = "Entite ...";
            entiteVM.PropertyChanged += EntiteVm_PropertyChanged;
            Entites.Add(entiteVM);
            OnPropertyChanged(nameof(SourceCode));
        }

        private void RemoveEntite(object param)
        {
            var entite = param as EntiteViewModel;
            if (entite != null && Entites.Contains(entite))
            {
                Entites.Remove(entite);
                OnPropertyChanged(nameof(SourceCode));
            }
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}