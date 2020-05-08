using Modelisateur.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelisateur.Services.DataVaultBuilder
{
    class LinkCreationRule : ICreationRule<Entite, Entite>
    {
        public Entite Create(Entite source)
        {
            throw new NotImplementedException();
        }

        public Task<Entite> CreateAsync(Entite source)
        {
            throw new NotImplementedException();
        }
    }
}
