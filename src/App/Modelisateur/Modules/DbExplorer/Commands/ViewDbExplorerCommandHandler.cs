using Gemini.Framework.Commands;
using Gemini.Framework.Services;
using Gemini.Framework.Threading;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Modelisateur.Modules.DbExplorer.Commands
{
    [CommandHandler]
    public class ViewExplorerCommandHandler : CommandHandlerBase<ViewDbExplorerCommandDefinition>
    {
        private readonly IShell _shell;

        [ImportingConstructor]
        public ViewExplorerCommandHandler(IShell shell)
        {
            _shell = shell;
        }

        public override Task Run(Command command)
        {
            _shell.ShowTool<IDbExplorerTool>();
            return TaskUtility.Completed;
        }
    }
}
