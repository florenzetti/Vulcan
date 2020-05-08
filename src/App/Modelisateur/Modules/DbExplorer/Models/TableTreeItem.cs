using System;
using System.Collections.Generic;
using System.Text;
using Gemini.Modules.Explorer.Models;
using Modelisateur.Connectors.Snowflake.Models;
using System.IO;

namespace Modelisateur.Modules.DbExplorer.Models
{
    public class TableTreeItem : TreeItem
    {
        public TableTreeItem(Table table) : base(Path.Combine(table.Database.Name, table.Name), table.Name)
        {
            foreach (var column in table.Columns)
            {
                AddChild(new ColumnTreeItem(column));
            }
        }
    }

    public class TableFolderTreeItem : FolderTreeItem
    {
        public TableFolderTreeItem(Schema schema) : base(Path.Combine(schema.Name, "tables"), "Tables")
        {
            foreach (var table in schema.Tables)
            {
                AddChild(new TableTreeItem(table));
            }
        }
    }
}
