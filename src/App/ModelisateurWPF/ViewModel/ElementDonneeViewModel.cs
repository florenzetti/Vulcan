using Modelisateur.Model;
using ModelisateurWPF.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ModelisateurWPF.ViewModel
{
    class ElementDonneeViewModel : TabViewModel, IViewModel
    {
        public ICommand InitForeignKeyCommand { get; }

        private ElementDonnee _elementDonnee;
        public string Name
        {
            get { return _elementDonnee.Name; }
            set
            {
                _elementDonnee.Name = value;
                OnPropertyChanged(Name);
            }
        }

        public string Type
        {
            get { return _elementDonnee.Type; }
            set
            {
                _elementDonnee.Type = value;
                OnPropertyChanged(Type);
            }
        }

        public bool IsKey
        {
            get { return _elementDonnee.IsKey; }
            set
            {
                _elementDonnee.IsKey = value;
                OnPropertyChanged(nameof(IsKey));
            }
        }

        //public LiaisonViewModel ForeignKey
        //{
        //    get 
        //    { 
        //        if(_elementDonnee.ForeignKey != null)
        //            return new LiaisonViewModel(_elementDonnee.ForeignKey, new RelayCommand(o => this.RemoveForeignKey()));
        //        return null;
        //    }
        //}

        public override object Model => _elementDonnee;

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public ElementDonneeViewModel() : this(new ElementDonnee()) 
        { }
        
        public ElementDonneeViewModel(ElementDonnee elementDonnee)
        {
            //InitForeignKeyCommand = new RelayCommand(o => this.InitForeignKey());
            _elementDonnee = elementDonnee;
        }

        //private void InitForeignKey()
        //{
        //    if (_elementDonnee.ForeignKey == null)
        //    {
        //        _elementDonnee.SetForeignKey(new Liaison());
        //        OnPropertyChanged(nameof(ForeignKey));
        //    }
        //}

        //private void RemoveForeignKey()
        //{
        //    _elementDonnee.RemoveForeignKey();
        //    OnPropertyChanged(nameof(ForeignKey));
        //}
    }
}