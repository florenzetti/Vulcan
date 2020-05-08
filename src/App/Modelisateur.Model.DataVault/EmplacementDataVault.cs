using Modelisateur.Model.DataVault.DataVaultBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Model.DataVault
{
    public class EmplacementDataVault : Emplacement
    {
        public static EmplacementDataVault Create(Emplacement source)
        {
            return new DataVaultCreationRule().Create(source);
        }
    }
}
