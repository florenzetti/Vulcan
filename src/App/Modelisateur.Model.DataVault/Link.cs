using Modelisateur.Model.DataVault.DataVaultBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Model.DataVault
{
    public class Link : DataVaultEntity
    {
        public override DataVaultEntityTypes Nature => DataVaultEntityTypes.Link;

        public static DataVaultEntity Create(Entite source)
        {
            return new LinkCreationRule().Create(source);
        }
    }
}
