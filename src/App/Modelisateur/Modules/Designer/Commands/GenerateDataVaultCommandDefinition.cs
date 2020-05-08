using Gemini.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Modules.Designer.Commands
{
    [CommandDefinition]
    public class GenerateDataVaultCommandDefinition : CommandDefinition
    {
        public const string CommandName = "Tools.GenerateDataVault";

        public override string Name => CommandName;
        public override string Text => "Generate DataVault";

        public override string ToolTip => "Generate DataVault";
    }
}
