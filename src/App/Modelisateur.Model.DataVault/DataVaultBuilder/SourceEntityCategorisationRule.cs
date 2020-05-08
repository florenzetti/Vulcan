using Modelisateur.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Modelisateur.Model.DataVault.DataVaultBuilder
{
    internal class SourceEntityCategorisationRule : ICategorisationRule<Entite, DataVaultEntityTypes>
    {
        public DataVaultEntityTypes Categorise(Entite entity)
        {
            if (entity.Name.StartsWith("Link_"))
                return DataVaultEntityTypes.Link;
            else
                return DataVaultEntityTypes.Hub;

        }
    }
}
