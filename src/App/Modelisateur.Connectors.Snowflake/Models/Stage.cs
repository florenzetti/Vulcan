using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Connectors.Snowflake.Models
{
    public class Stage : MetadataBase
    {
        public Schema Schema { get; set; }
    }
}
