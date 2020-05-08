using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Connectors.Snowflake.Models
{
    public class Schema : MetadataBase
    {
        public Database Database { get; set; }
        public IList<Table> Tables { get; }
        public IList<View> Views { get; }
        public IList<Stage> Stages { get; }

        public Schema()
        {
            Tables = new List<Table>();
            Views = new List<View>();
            Stages = new List<Stage>();
        }
    }
}
