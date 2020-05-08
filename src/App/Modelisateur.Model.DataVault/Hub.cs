using Modelisateur.Model.DataVault.DataVaultBuilder;
using System;

namespace Modelisateur.Model.DataVault
{
    public class Hub : DataVaultEntity
    {
        public override DataVaultEntityTypes Nature => DataVaultEntityTypes.Hub;
        public static DataVaultEntity Create(Entite source)
        {
            return new HubCreationRule().Create(source);
        }
    }
}