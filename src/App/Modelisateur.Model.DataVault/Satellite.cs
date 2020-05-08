using Modelisateur.Model.DataVault.DataVaultBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Model.DataVault
{
    public class Satellite : DataVaultEntity
    {
        public override DataVaultEntityTypes Nature => DataVaultEntityTypes.Satellite;

        public static DataVaultEntity Create(Entite source)
        {
            return new SatelliteCreationRule().Create(source);
        }
    }
}
