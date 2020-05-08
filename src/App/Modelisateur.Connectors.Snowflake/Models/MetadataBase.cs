using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Connectors.Snowflake.Models
{
    public abstract class MetadataBase : Base
    {
        public DateTime Created { get; set; }
        public string Owner { get; set; }
        public string Comment { get; set; }
    }
}
