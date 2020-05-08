using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;
using Modelisateur.Modules.Designer.ViewModels;
using Gemini.Framework.Commands;
using Gemini.Framework.Services;
using Gemini.Modules.Inspector;
using Microsoft.Win32;
using Modelisateur.Model;
using Modelisateur.Model.Repositories;
using Gemini.Modules.PropertyGrid;
using Modelisateur.Modules.Designer.Design;

namespace Modelisateur.Modules.Designer.Commands
{
    [CommandHandler]
    public class OpenGraphCommandHandler : CommandHandlerBase<OpenGraphCommandDefinition>
    {
        private readonly IShell _shell;

        [ImportingConstructor]
        public OpenGraphCommandHandler(IShell shell)
        {
            _shell = shell;
        }

        public override async Task Run(Command command)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                EmplacementRepository repository = new EmplacementRepository(fileDialog.FileName);
                //_shell.OpenDocument(new GraphViewModel(IoC.Get<IInspectorTool>(), IoC.Get<IPropertyGrid>(), repository));
                await _shell.OpenDocumentAsync(new GraphViewModel(IoC.Get<IInspectorTool>(), IoC.Get<IPropertyGrid>(), repository));
            }
        }
    }
}
