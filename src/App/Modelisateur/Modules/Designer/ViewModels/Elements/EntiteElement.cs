using System.Linq;
using System.Collections.Generic;
using System.Windows.Media;
using Modelisateur.Model;
using Caliburn.Micro;
using System.ComponentModel;
using ToolboxItemAttribute = Gemini.Modules.Toolbox.ToolboxItemAttribute;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using System;
using Modelisateur.Base;

namespace Modelisateur.Modules.Designer.ViewModels.Elements
{
    [ToolboxItem(typeof(GraphViewModel), "Entite", "Objects", "pack://application:,,,/Modules/FilterDesigner/Resources/color_swatch.png")]
    class EntiteElement : ElementViewModel
    {
        private Entite _entite;

        [Browsable(false)]
        public override object Model
        {
            get { return _entite; }
            set
            {
                SetModel(value);
                //NotifyOfPropertyChange(() => Model);
            }
        }

        public override object PreviewObject => ElementsDonnees;

        private ViewModelCollection<ElementDonneeElement, ElementDonnee> _elementsDonnees;

        public override event EventHandler NameChanged;

        [Editor(typeof(CollectionEditor), typeof(CollectionEditor))]
        public IList<ElementDonneeElement> ElementsDonnees => _elementsDonnees;

        public override string Name
        {
            get
            {
                return _entite?.Name;
            }
            set
            {
                _entite.Name = value;
                NameChanged?.Invoke(this, new EventArgs());
                NotifyOfPropertyChange(() => Name);
            }
        }

        public EntiteElement()
        {
            SetModel(new Entite());
        }

        private void SetModel(object model)
        {
            _entite = (Entite)model;
            _elementsDonnees = new ViewModelCollection<ElementDonneeElement, ElementDonnee>(_entite.ElementsDonnees);
            //_elementsDonnees.Clear();
            //foreach (var elementDonnee in _entite.ElementsDonnees)
            //{
            //    _elementsDonnees.Add(new ElementDonneeElement() { Model = elementDonnee });
            //}

            ClearOutputConnectors();
            foreach (var liaison in _entite.Liaisons)
            {
                AddOutputConnector(liaison.NameEntite, Colors.DarkSeaGreen, () => liaison);
            }
            AddOutputConnector("New FK", Colors.DarkSeaGreen);
        }
    }
}