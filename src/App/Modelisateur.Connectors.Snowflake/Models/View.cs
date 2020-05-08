using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Connectors.Snowflake.Models
{
    public class View : MetadataBase
    {
        public Schema Schema { get; set; }
        public string Definition { get; set; }
    }
}
