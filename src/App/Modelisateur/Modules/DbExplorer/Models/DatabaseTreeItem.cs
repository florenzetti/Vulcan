using System;
using System.Collections.Generic;
using System.Text;
using Gemini.Modules.Explorer.Models;
using Modelisateur.Connectors.Snowflake.Models;

namespace Modelisateur.Modules.DbExplorer.Models
{
    public class DatabaseTreeItem : FolderTreeItem
    {
        public DatabaseTreeItem(Database database) : base(System.IO.Path.Combine("Server", database.Name), database.Name)
        {
            foreach (var schema in database.Schemas)
            {
                AddChild(new SchemaTreeItem(schema));
            }
        }
    }
}
