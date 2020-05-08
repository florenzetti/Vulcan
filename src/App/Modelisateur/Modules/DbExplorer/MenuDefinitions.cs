using Gemini.Framework.Menus;
using Modelisateur.Modules.DbExplorer.Commands;
using System.ComponentModel.Composition;

namespace Modelisateur.Modules.DbExplorer
{
    public static class MenuDefinitions
    {
        [Export]
        public static MenuItemDefinition ViewDbExplorerMenuItem = new CommandMenuItemDefinition<ViewDbExplorerCommandDefinition>(
            Gemini.Modules.MainMenu.MenuDefinitions.ViewToolsMenuGroup, 1);
    }
}
