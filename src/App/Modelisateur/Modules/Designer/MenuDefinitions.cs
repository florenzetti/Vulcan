using System.ComponentModel.Composition;
using Modelisateur.Modules.Designer.Commands;
using Gemini.Framework.Menus;

namespace Modelisateur.Modules.Designer
{
    public static class MenuDefinitions
    {
        [Export]
        public static MenuItemDefinition OpenGraphMenuItem = new CommandMenuItemDefinition<OpenGraphCommandDefinition>(
            Gemini.Modules.MainMenu.MenuDefinitions.FileNewOpenMenuGroup, 2);

        //group models
        [Export]
        public static MenuItemDefinition ModelsMenuItem = new TextMenuItemDefinition(
            Gemini.Modules.MainMenu.MenuDefinitions.ToolsOptionsMenuGroup, 0, "Models");
        [Export]
        public static MenuItemGroupDefinition ModelsGroup = new MenuItemGroupDefinition(ModelsMenuItem, 0);
        [Export]
        public static MenuItemDefinition ImportModelMenuItem = new TextMenuItemDefinition(
            ModelsGroup, 1, "Import model...");
        [Export]
        public static MenuItemDefinition GenerateDataVaultItem = new CommandMenuItemDefinition<GenerateDataVaultCommandDefinition>(
            ModelsGroup, 2);
        [Export]
        public static MenuItemDefinition GenerateSqlMenuItem = new CommandMenuItemDefinition<GenerateSqlCommandDefinition>(
            ModelsGroup, 3);
    }
}