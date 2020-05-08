using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelisateur.Services.SqlParser
{
    class PrimaryKeySqlExpression : ISqlExpression
    {
        private ICollection<string> _columnNames;
        private bool _clustered;
        public PrimaryKeySqlExpression(ICollection<string> columnNames, bool clustered)
        {
            if (columnNames == null)
                throw new ArgumentNullException(nameof(columnNames));

            _columnNames = columnNames;
            _clustered = clustered;
        }

        public string SqlExpression
        {
            get
            {
                string strClustered = _clustered ? "CLUSTERED" : "NONCLUSTERED";
                return string.Format("PRIMARY KEY {0} ({1})", strClustered, string.Join(", ", _columnNames));
            }
        }
    }
}