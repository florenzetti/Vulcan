using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Connectors.Snowflake.Models
{
    public class Database : MetadataBase
    {
        public IList<Schema> Schemas { get; }

        public Database()
        {
            Schemas = new List<Schema>();
        }
    }
}
