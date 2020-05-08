using Modelisateur.Base;
using Modelisateur.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Modelisateur.Modules.Designer.ViewModels.Connections
{
    public class LiaisonConnection : ConnectionViewModel
    {
        private Liaison _liaison = new Liaison();

        [Browsable(false)]
        public override object Model
        {
            get => _liaison;
            set
            {
                _liaison = (Liaison)value;
            }
        }

        public override OutputConnectorViewModel From
        {
            get => base.From;
            protected set 
            {
                _liaison.NameEntite = value.Element.Name;
                base.From = value;
            }
        }

        [DisplayName("From")]
        public string FromElementName => From.Element.Name;

        [DisplayName("To")]
        public string ToElementName => To.Element.Name;

        [Editor(typeof(PrimitiveTypeCollectionEditor), typeof(PrimitiveTypeCollectionEditor))]
        public IList<string> ElementsDonnees => _liaison.ElementsDonnees;

        public LiaisonConnection(OutputConnectorViewModel from) : this(from, null)
        {
        }

        public LiaisonConnection(OutputConnectorViewModel from, InputConnectorViewModel to) : base(from, to)
        {
            _liaison = new Liaison();
        }
    }
}
