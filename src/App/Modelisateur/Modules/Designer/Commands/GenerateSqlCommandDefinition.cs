using Gemini.Framework.Commands;

namespace Modelisateur.Modules.Designer.Commands
{
    [CommandDefinition]
    public class GenerateSqlCommandDefinition : CommandDefinition
    {
        public const string CommandName = "Tools.GenerateSql";

        public override string Name => CommandName;

        public override string Text => "Generate Sql";

        public override string ToolTip => "Generate Sql";
    }
}
