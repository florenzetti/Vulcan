using System;
using System.Windows.Media;
using Caliburn.Micro;
using Modelisateur.Base;
using Modelisateur.Model;
using Modelisateur.Modules.Designer.ViewModels.Elements;

namespace Modelisateur.Modules.Designer.ViewModels
{
    public class OutputConnectorViewModel : ConnectorViewModel
    {
        public event EventHandler OutputChanged;
        public event EventHandler DestinationChanged;

        private readonly Func<Liaison> _valueCallback;

        public override ConnectorDirection ConnectorDirection
        {
            get { return ConnectorDirection.Output; }
        }

        //private readonly BindableCollection<ConnectionViewModel> _connections;
        //public IObservableCollection<ConnectionViewModel> Connections
        //{
        //    get { return _connections; }
        //}
        private ConnectionViewModel _connection;
        public ConnectionViewModel Connection
        {
            get { return _connection; }
            set 
            { 
                _connection = value;
            }
        }

        public Liaison Value
        {
            get { return _valueCallback(); }
        }

        public OutputConnectorViewModel(ElementViewModel element, string name, Color color, Func<Liaison> valueCallback)
            : base(element, name, color)
        {
            //_connections = new BindableCollection<ConnectionViewModel>();
            _valueCallback = valueCallback;
        }

        protected virtual void RaiseOutputChanged()
        {
            OutputChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void RaiseDestinationChanged()
        {
            DestinationChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}