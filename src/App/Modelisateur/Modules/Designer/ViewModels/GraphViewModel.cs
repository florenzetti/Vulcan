using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;
using Gemini.Framework;
using Gemini.Modules.Inspector;
using Modelisateur.Modules.Designer.ViewModels.Elements;
using Modelisateur.Model;
using Modelisateur.Model.DataVault;
using Modelisateur.Base;
using Gemini.Modules.PropertyGrid;
using Modelisateur.Modules.Designer.ViewModels.Connections;
using System.Threading.Tasks;
using Modelisateur.Model.Repositories;
using System;
using Gemini.Framework.Commands;
using Modelisateur.Modules.Designer.Commands;
using Gemini.Framework.Services;
using Modelisateur.Services.SqlParser;
//using Modelisateur.Modules.TextEditor.ViewModels;
using System.IO;
using Gemini.Framework.Threading;

namespace Modelisateur.Modules.Designer.ViewModels
{
    [Export(typeof(GraphViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GraphViewModel : PersistedDocument,
        IViewModel,
        ICommandHandler<GenerateDataVaultCommandDefinition>,
        ICommandHandler<GenerateSqlCommandDefinition>
    {
        private readonly IInspectorTool _inspectorTool;
        private readonly IPropertyGrid _propertyGrid;

        private readonly BindableCollection<ElementViewModel> _elements;
        public IObservableCollection<ElementViewModel> Elements
        {
            get { return _elements; }
        }

        private readonly BindableCollection<ConnectionViewModel> _connections;
        public IObservableCollection<ConnectionViewModel> Connections
        {
            get { return _connections; }
        }

        public IEnumerable<ElementViewModel> SelectedElements
        {
            get { return _elements.Where(x => x.IsSelected); }
        }

        private Emplacement _emplacement;
        public object Model
        {
            get => _emplacement;
            set { throw new NotImplementedException(); }
        }

        private readonly EmplacementRepository _repository;

        [ImportingConstructor]
        public GraphViewModel(IInspectorTool inspectorTool, IPropertyGrid propertyGrid, EmplacementRepository repository)
        {
            _inspectorTool = inspectorTool;
            _propertyGrid = propertyGrid;
            _repository = repository;
            _emplacement = _repository.Load();

            _elements = new BindableCollection<ElementViewModel>();
            _connections = new BindableCollection<ConnectionViewModel>();

            DisplayName = _emplacement.Name;

            double x = 100;
            double y = 50;

            foreach (var entite in _emplacement.Entites)
            {
                var element = AddElement<EntiteElement, Entite>(x, y, entite);
                x += 450;
                if (x > 1000)
                {
                    y += 150;
                    x = 100;
                }
            }

            foreach (var output in Elements.SelectMany(o => o.OutputConnectors))
            {
                var element = Elements.FirstOrDefault(o => o.Name == output.Value.NameEntite);
                if (element != null)
                {
                    var input = element.AddInputConnector(output.Element.Name, Colors.DarkBlue);
                    Connections.Add(new LiaisonConnection(output, input) { Model = output.Value });
                }
            }
        }

        public TElement AddElement<TElement, TModel>(double x, double y, TModel model)
            where TElement : ElementViewModel, new()
        {
            var element = new TElement() { X = x, Y = y, Model = model };
            _elements.Add(element);
            return element;
        }

        public ConnectionViewModel OnConnectionDragStarted(ConnectorViewModel sourceConnector, Point currentDragPoint)
        {
            if (!(sourceConnector is OutputConnectorViewModel))
                return null;

            var connection = new LiaisonConnection((OutputConnectorViewModel)sourceConnector)
            {
                ToPosition = currentDragPoint
            };

            Connections.Add(connection);

            return connection;
        }

        public void OnConnectionSelected(Point currentSelectPoind)
        {

        }

        public void OnConnectionDragging(Point currentDragPoint, ConnectionViewModel connection)
        {
            //If current drag point is close to an input connector, show its snapped position.
            var nearbyConnector = FindNearbyInputConnector(currentDragPoint);
            connection.ToPosition = (nearbyConnector != null)
                ? nearbyConnector.Position
                : currentDragPoint;
        }

        public void OnConnectionDragCompleted(Point currentDragPoint, ConnectionViewModel newConnection, ConnectorViewModel sourceConnector)
        {
            //var nearbyConnector = FindNearbyInputConnector(currentDragPoint);
            var destinationElement = FindNearbyElement(currentDragPoint);

            //same destination
            if (destinationElement == null)
            //|| Connections.Any(o => o.To?.Element == destinationElement && o.From?.Element == sourceConnector.Element)
            //|| Connections.Any(o => o.From?.Element == destinationElement && o.To?.Element == sourceConnector.Element))
            {
                Connections.Remove(newConnection);
                return;
            }

            //if outputconnector is already connected
            var existingConnection = Connections.FirstOrDefault(o => o.From == sourceConnector && o != newConnection);
            if (existingConnection != null)
                DeleteConnection(existingConnection, true, false);

            var newDestInputConnector = destinationElement.AddInputConnector(sourceConnector.Element.Name, Colors.DarkBlue);
            sourceConnector.Name = destinationElement.Name;

            if (sourceConnector.Element.OutputConnectors.Any(o => o.Connection != null))
            {
                sourceConnector.Element.AddOutputConnector("New FK", Colors.DarkSeaGreen);
            }

            newConnection.To = newDestInputConnector;

            //model
            var entiteModel = sourceConnector.Element.Model as Entite;
            var liaisonModel = new Liaison() { NameEntite = destinationElement.Name };
            entiteModel.Liaisons.Add(liaisonModel);
            newConnection.Model = liaisonModel;
        }

        private InputConnectorViewModel FindNearbyInputConnector(Point mousePosition)
        {
            return Elements.SelectMany(x => x.InputConnectors)
                .FirstOrDefault(x => AreNearby(x.Position, mousePosition, 10));
        }

        private ElementViewModel FindNearbyElement(Point mousePosition)
        {
            return Elements.FirstOrDefault(x => AreIn(x.Location, mousePosition));
        }

        private static bool AreNearby(Point point1, Point point2, double distance)
        {
            return (point1 - point2).Length < distance;
        }

        private static bool AreIn(Rect location, Point point)
        {
            return location.Contains(point);
        }

        private void DeleteElement(ElementViewModel element)
        {
            element.AttachedConnections.ToList().ForEach(DeleteConnection);
            Elements.Remove(element);
            _emplacement.Entites.Remove((Entite)element.Model);
        }

        private void DeleteConnection(ConnectionViewModel connection)
        {
            DeleteConnection(connection, true, true);
        }
        private void DeleteConnection(ConnectionViewModel connection, bool deleteInputConnector, bool deleteOutputConnector)
        {
            var element = connection.To?.Element;
            if (deleteInputConnector && element != null)
                element.RemoveInputConnector(connection.To);
            element = connection.From?.Element;
            if (deleteOutputConnector && element != null)
                element.RemoveOutputConnector(connection.From);

            Connections.Remove(connection);
            ((Entite)element.Model).Liaisons.Remove((Liaison)connection.Model);
        }

        public void DeleteSelectedElements()
        {
            Elements.Where(x => x.IsSelected)
                .ToList()
                .ForEach(DeleteElement);
            Connections.Where(x => x.Selected)
                .ToList()
                .ForEach(DeleteConnection);
        }

        public void OnSelectionChanged()
        {
            var selectedElements = SelectedElements.ToList();
            var selectedConnections = Connections.Where(o => o.Selected).ToList();
            if (selectedElements.Count == 1)
            {
                _inspectorTool.SelectedObject = new InspectableObjectBuilder()
                    .WithObjectProperties(selectedElements[0], x => true)
                    .ToInspectableObject();

                _propertyGrid.SelectedObject = selectedElements[0];
            }
            else if (selectedConnections.Count == 1)
            {
                _propertyGrid.SelectedObject = selectedConnections[0];
            }
            else
            {
                _inspectorTool.SelectedObject = null;
                _propertyGrid.SelectedObject = null;
            }
        }

        public object NewElementModel()
        {
            Entite model = new Entite();
            _emplacement.Entites.Add(model);
            return model;
        }

        protected override async Task DoNew()
        {
            _emplacement = _repository.Load();
        }

        protected override async Task DoLoad(string filePath)
        {
            _emplacement = await _repository.LoadAsync();
        }

        protected override async Task DoSave(string filePath)
        {
            _repository.Save(_emplacement, true);
            DisplayName = _emplacement.Name;
        }

        public void Update(Command command)
        {
            command.Enabled = true;
        }

        public Task Run(Command command)
        {
            Task result = TaskUtility.Completed;
            switch (command.CommandDefinition.Name)
            {
                case GenerateDataVaultCommandDefinition.CommandName:
                    result = GenerateDataVault();
                    break;
                case GenerateSqlCommandDefinition.CommandName:
                    result = OpenFile();
                    break;
            }

            return result;
        }

        private Task GenerateDataVault()
        {
            var newEmplacement = EmplacementDataVault.Create(_emplacement);
            EmplacementRepository repository = new EmplacementRepository($@"c:\temp\{newEmplacement.Name}.json");
            repository.Save(newEmplacement, true);
            //IoC.Get<IShell>().OpenDocument(new GraphViewModel(IoC.Get<IInspectorTool>(), IoC.Get<IPropertyGrid>(), repository));
            IoC.Get<IShell>().OpenDocumentAsync(new GraphViewModel(IoC.Get<IInspectorTool>(), IoC.Get<IPropertyGrid>(), repository));
            return TaskUtility.Completed;
        }

        private Task<IDocument> GenerateSql()
        {
            string fileName = $@"c:\temp\{_emplacement.Name}Sql.sql";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                EmplacementSqlCreator sqlCreator = new EmplacementSqlCreator();
                writer.Write(sqlCreator.Create(_emplacement));
            }
            var editor = IoC.Get<IEditorProvider>().Create();

            var viewAware = (IViewAware)editor;
            viewAware.ViewAttached += (sender, e) =>
            {
                var frameworkElement = (FrameworkElement)e.View;

                RoutedEventHandler loadedHandler = null;
                loadedHandler = async (sender2, e2) =>
                {
                    frameworkElement.Loaded -= loadedHandler;
                    await IoC.Get<IEditorProvider>().Open(editor, fileName);
                };
                frameworkElement.Loaded += loadedHandler;
            };

            return Task.FromResult(editor);
        }

        private async Task OpenFile()
        {
            //IoC.Get<IShell>().OpenDocument(await GenerateSql());
            await IoC.Get<IShell>().OpenDocumentAsync(await GenerateSql());
        }
    }
}