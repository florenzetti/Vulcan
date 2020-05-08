using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Connectors.Snowflake.Models
{
    public class Column : Base
    {
        public Table Table { get; }
        public string Type { get; set; }

        public Column(Table table)
        {
            Table = table;
        }
    }
}
