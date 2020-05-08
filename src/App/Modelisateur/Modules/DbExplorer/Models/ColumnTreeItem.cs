using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Modules.DbExplorer.Models
{
    public class ColumnTreeItem : Gemini.Modules.Explorer.Models.TreeItem
    {
        public ColumnTreeItem(Connectors.Snowflake.Models.Column column) : base(System.IO.Path.Combine(column.Table.Name, column.Name), column.Name)
        {
        }
    }
}
