using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Caliburn.Micro;
using Modelisateur.Base;
using Modelisateur.Model;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Modelisateur.Modules.Designer.ViewModels
{
    public abstract class ConnectionViewModel : PropertyChangedBase, IViewModel
    {
        //private Liaison _liaison;

        [Browsable(false)]
        public new bool IsNotifying
        {
            get => base.IsNotifying;
            set { base.IsNotifying = value; }
        }

        [Browsable(false)]
        public abstract object Model { get; set; }

        //[Editor(typeof(CollectionEditor), typeof(CollectionEditor))]
        //public IList<string> ElementsDonnees
        //{
        //    get => _liaison?.ElementsDonnees;
        //    set { _liaison.ElementsDonnees = value; }
        //}

        private bool _selected;
        [Browsable(false)]
        public bool Selected 
        {
            get => _selected;
            set 
            { 
                _selected = value;
                NotifyOfPropertyChange(() => Selected);
            }
        }
        private OutputConnectorViewModel _from;
        [Browsable(false)]
        public virtual OutputConnectorViewModel From
        {
            get { return _from; }
            protected set
            {
                if (_from != null)
                {
                    _from.PositionChanged -= OnFromPositionChanged;
                    _from.Element.NameChanged -= OnFromElementNameChanged;
                    _from.Connection = null;
                }

                _from = value;

                if (_from != null)
                {
                    _from.PositionChanged += OnFromPositionChanged;
                    _from.Element.NameChanged += OnFromElementNameChanged;
                    //_from.Connections.Add(this);
                    _from.Connection = this;
                    FromPosition = value.Position;
                }

                NotifyOfPropertyChange(() => From);
            }
        }

        private InputConnectorViewModel _to;
        [Browsable(false)]
        public virtual InputConnectorViewModel To
        {
            get { return _to; }
            set
            {
                if (_to != null)
                {
                    _to.PositionChanged -= OnToPositionChanged;
                    _to.Element.NameChanged -= OnToElementNameChanged;
                    _to.Connection = null;
                }

                _to = value;
                //_liaison.NameEntite = _to.Element.Name;
                if (_to != null)
                {
                    _to.PositionChanged += OnToPositionChanged;
                    _to.Element.NameChanged += OnToElementNameChanged;
                    _to.Connection = this;
                    ToPosition = _to.Position;
                }

                NotifyOfPropertyChange(() => To);
            }
        }

        private Point _fromPosition;
        [Browsable(false)]
        public Point FromPosition
        {
            get { return _fromPosition; }
            set
            {
                _fromPosition = value;
                NotifyOfPropertyChange(() => FromPosition);
            }
        }

        private Point _toPosition;
        [Browsable(false)]
        public Point ToPosition
        {
            get { return _toPosition; }
            set
            {
                _toPosition = value;
                NotifyOfPropertyChange(() => ToPosition);
            }
        }

        public ConnectionViewModel(OutputConnectorViewModel from, InputConnectorViewModel to)
        {
            //_liaison = new Liaison();
            From = from;
            To = to;
        }

        public ConnectionViewModel(OutputConnectorViewModel from)
        {
            From = from;
        }

        private void OnFromPositionChanged(object sender, EventArgs e)
        {
            FromPosition = From.Position;
        }
        private void OnFromElementNameChanged(object sender, EventArgs e)
        {
            To.Name = From.Element.Name;
        }
        private void OnToPositionChanged(object sender, EventArgs e)
        {
            ToPosition = To.Position;
        }
        private void OnToElementNameChanged(object sender, EventArgs e)
        {
            From.Name = To.Element.Name;
        }
    }
}