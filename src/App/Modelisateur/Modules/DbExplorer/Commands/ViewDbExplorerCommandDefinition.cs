using Gemini.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Modules.DbExplorer.Commands
{
    [CommandDefinition]
    public class ViewDbExplorerCommandDefinition : CommandDefinition
    {
        public const string CommandName = "View.DbExplorer";
        public override string Name => CommandName;
        public override string Text => "Database explorer";
        public override string ToolTip => "Database explorer";
    }
}
