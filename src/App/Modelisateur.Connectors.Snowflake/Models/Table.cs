using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Connectors.Snowflake.Models
{
    public class Table : MetadataBase
    {
        public Database Database { get; set; }
        public Schema Schema { get; set; }
        public IList<Column> Columns { get; }

        public Table()
        {
            Columns = new List<Column>();
        }
    }
}
