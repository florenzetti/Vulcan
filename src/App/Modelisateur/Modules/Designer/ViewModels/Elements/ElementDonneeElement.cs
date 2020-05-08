using Modelisateur.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Modelisateur.Modules.Designer.ViewModels.Elements
{
    public class ElementDonneeElement : ElementViewModel
    {
        private ElementDonnee _elementDonnee;

        public override event EventHandler NameChanged;

        public override object PreviewObject => $"{Name}: {Type}";

        public override object Model 
        { 
            get => _elementDonnee; 
            set => _elementDonnee = value as ElementDonnee; 
        }
        public override string Name
        {
            get => _elementDonnee.Name;
            set => _elementDonnee.Name = value;
        }

        [Category("Base")]
        public string Type 
        {   get => _elementDonnee.Type;
            set => _elementDonnee.Type = value;
        }

        [DisplayName("Key"), Category("Attributes")]
        public bool Key
        {
            get => _elementDonnee.IsKey;
            set => _elementDonnee.IsKey = value;
        }

        [Category("Attributes")]
        public bool Required 
        {
            get => _elementDonnee.Required;
            set => _elementDonnee.Required = value;
        }

        public ElementDonneeElement()
        {
            _elementDonnee = new ElementDonnee();
        }

        public override string ToString()
        {
            return _elementDonnee.Name;
        }
    }
}
