using System;
using System.Collections.Generic;
using System.Text;
using Gemini.Modules.Explorer.Models;
using Modelisateur.Connectors.Snowflake.Models;
using System.IO;
namespace Modelisateur.Modules.DbExplorer.Models
{
    public class SchemaTreeItem : TreeItem
    {
        public SchemaTreeItem(Schema schema) : base(Path.Combine(schema.Database.Name, schema.Name), schema.Name)
        {
            AddChild(new TableFolderTreeItem(schema));
        }
    }

    public class SchemaFolderTreeItem : FolderTreeItem
    {
        public SchemaFolderTreeItem(Database database) : base(Path.Combine(database.Name, "Schemas"), "Schemas")
        {
            foreach (var schema in database.Schemas)
            {
                AddChild(new SchemaTreeItem(schema));
            }
        }
    }
}
