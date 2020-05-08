using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Model.DataVault.DataVaultBuilder
{
    internal static class DataVaultConvetions
    {
        public static string PrefixedEntiteName(DataVaultEntityTypes entiteType, string name)
        {
            string prefix = string.Empty;
            switch (entiteType)
            {
                case DataVaultEntityTypes.Hub:
                    prefix = $"Hub_{name}";
                    break;
                case DataVaultEntityTypes.Link:
                    //prefix = $"Link_{name}";
                    prefix = name;
                    break;
                case DataVaultEntityTypes.Satellite:
                    prefix = $"Sat_{name}";
                    break;
            }
            return prefix;
        }
    }
}
