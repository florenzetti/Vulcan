using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;
using Modelisateur.Base;
using Modelisateur.Model;
using Modelisateur.Modules.Designer.ViewModels.Elements;

namespace Modelisateur.Modules.Designer.ViewModels
{
    public abstract class ElementViewModel : PropertyChangedBase, IViewModel
    {
        public event EventHandler PositionChanged;
        public abstract event EventHandler NameChanged;

        private double _previewHeight = 100;
        [Browsable(false)]
        public double PreviewHeight 
        {
            get => _previewHeight;
            set
            {
                _previewHeight = value;
                NotifyOfPropertyChange(() => PreviewHeight);
            }
        }
        private double _previewWidth = 100;
        [Browsable(false)]
        public double PreviewWidth
        {
            get => _previewWidth;
            set
            {
                _previewWidth = value;
                NotifyOfPropertyChange(() => PreviewWidth);
            }
        }
        [Browsable(false)]
        public abstract object Model { get; set; }
        [Browsable(false)]
        public abstract object PreviewObject { get; }

        [Browsable(false)]
        public new bool IsNotifying
        {
            get => base.IsNotifying;
            set => base.IsNotifying = value;
        }

        [Category("Base")]
        public abstract string Name { get; set; }

        private double _x;

        [Browsable(false)]
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                NotifyOfPropertyChange(() => X);
            }
        }

        private double _y;

        [Browsable(false)]
        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                NotifyOfPropertyChange(() => Y);
            }
        }

        private double _width;

        [Browsable(false)]
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                NotifyOfPropertyChange(() => Width);
            }
        }

        private double _height;
        [Browsable(false)]
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                NotifyOfPropertyChange(() => Height);
            }
        }

        private bool _isSelected;

        [Browsable(false)]
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }

        [Browsable(false)]
        public Rect Location
        {
            get { return new Rect(_x, _y, _width, _height); }
        }

        private readonly BindableCollection<InputConnectorViewModel> _inputConnectors;
        [Browsable(false)]
        public IReadOnlyList<InputConnectorViewModel> InputConnectors
        {
            get { return _inputConnectors; }
        }

        private readonly BindableCollection<OutputConnectorViewModel> _outputConnectors;
        [Browsable(false)]
        public IReadOnlyList<OutputConnectorViewModel> OutputConnectors
        {
            get { return _outputConnectors; }
        }

        [Browsable(false)]
        public IEnumerable<ConnectionViewModel> AttachedConnections
        {
            get
            {
                return _inputConnectors.Select(x => x.Connection)
                    .Union(_outputConnectors.Select(o => o.Connection))
                    .Where(x => x != null);
            }
        }

        protected ElementViewModel()
        {
            _inputConnectors = new BindableCollection<InputConnectorViewModel>();
            _outputConnectors = new BindableCollection<OutputConnectorViewModel>();
        }

        public InputConnectorViewModel AddInputConnector(string name, Color color)
        {
            var inputConnector = new InputConnectorViewModel(this, name, color);
            inputConnector.SourceChanged += OnInputConnectorSourceChanged;
            _inputConnectors.Add(inputConnector);
            return inputConnector;
        }

        public OutputConnectorViewModel AddOutputConnector(string name, Color color)
        {
            return AddOutputConnector(name, color, () => new Liaison());
        }

        public OutputConnectorViewModel AddOutputConnector(string name, Color color, Func<Liaison> valueCallback)
        {
            var outputConnector = new OutputConnectorViewModel(this, name, color, valueCallback);
            outputConnector.DestinationChanged += OutputConnectorDestinationChanged;
            _outputConnectors.Add(outputConnector);
            return outputConnector;
        }

        public void RemoveInputConnector(InputConnectorViewModel inputConnector)
        {
            _inputConnectors.Remove(inputConnector);
        }

        public void ClearInputConnectors()
        {
            _inputConnectors.Clear();
        }

        public void RemoveOutputConnector(OutputConnectorViewModel outputConnector)
        {
            _outputConnectors.Remove(outputConnector);
        }

        public void ClearOutputConnectors()
        {
            _outputConnectors.Clear();
        }

        protected virtual void OnInputConnectorSourceChanged(object sender, EventArgs e)
        {
        }

        protected virtual void OutputConnectorDestinationChanged(object sender, EventArgs e)
        {
        }

        private void RaisePositionChanged()
        {
            PositionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}