using Modelisateur.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelisateur.Model.DataVault.DataVaultBuilder
{
    internal class DataVaultCreationRule : ICreationRule<Emplacement, EmplacementDataVault>
    {
        //private IEnumerable<ICreationRule<Entite, DataVaultEntity>> _creationRules;
        private SourceEntityCategorisationRule _sourceCategorisationRule;
        //TODO: Evaluate how to do Dependency injection
        public DataVaultCreationRule()
        {
            //var rules = new List<ICreationRule<Entite, DataVaultEntity>>();
            //rules.Add(new HubCreationRule());
            //rules.Add(new SatelliteCreationRule());
            //rules.Add(new LinkCreationRule());
            //rules.Add(new SatLinkCreationRule());
            //_creationRules = rules;
            _sourceCategorisationRule = new SourceEntityCategorisationRule();
        }

        public EmplacementDataVault Create(Emplacement source)
        {
            var newEmplacement = new EmplacementDataVault() { Name = $"RDV{source.Name}" };
            foreach (var entite in source.Entites)
            {
                switch (_sourceCategorisationRule.Categorise(entite))
                {
                    case DataVaultEntityTypes.Hub:
                        newEmplacement.Entites.Add(Hub.Create(entite));
                        newEmplacement.Entites.Add(Satellite.Create(entite));
                        break;
                    case DataVaultEntityTypes.Link:
                        newEmplacement.Entites.Add(Link.Create(entite));
                        newEmplacement.Entites.Add(Satellite.Create(entite));
                        break;
                }
            }

            return newEmplacement;
        }

        public async Task<EmplacementDataVault> CreateAsync(Emplacement source)
        {
            return Create(source);
        }
    }
}