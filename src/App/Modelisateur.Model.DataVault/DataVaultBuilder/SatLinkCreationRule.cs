using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Modelisateur.Model;

namespace Modelisateur.Model.DataVault.DataVaultBuilder
{
    internal class SatLinkCreationRule : ICreationRule<Entite, DataVaultEntity>
    {
        public DataVaultEntity Create(Entite source)
        {
            return new Satellite();
        }

        public async Task<DataVaultEntity> CreateAsync(Entite source)
        {
            return Create(source);
        }
    }
}
