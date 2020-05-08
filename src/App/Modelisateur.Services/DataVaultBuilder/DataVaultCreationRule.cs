using Modelisateur.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelisateur.Services.DataVaultBuilder
{
    public class DataVaultCreationRule : ICreationRule<Emplacement, Emplacement>
    {
        private IEnumerable<ICreationRule<Entite, Entite>> _creationRules;
        private SourceEntityCategorisationRule _sourceCategorisationRule;
        //TODO: Evaluate how to do Dependency injection
        public DataVaultCreationRule()
        {
            var rules = new List<ICreationRule<Entite, Entite>>();
            rules.Add(new HubCreationRule());
            rules.Add(new SatelliteCreationRule());
            rules.Add(new LinkCreationRule());
            rules.Add(new SatLinkCreationRule());
            _creationRules = rules;
            _sourceCategorisationRule = new SourceEntityCategorisationRule();
        }

        public Emplacement Create(Emplacement source)
        {
            var newEmplacement = new Emplacement() { Name = $"RDV{source.Name}" };
            foreach (var entite in source.Entites)
            {
                switch (_sourceCategorisationRule.Categorise(entite))
                {
                    case DataVaultEntityTypes.Hub:
                        newEmplacement.Entites.Add(_creationRules.First(o => o.GetType() == typeof(HubCreationRule)).Create(entite));
                        newEmplacement.Entites.Add(_creationRules.First(o => o.GetType() == typeof(SatelliteCreationRule)).Create(entite));
                        break;
                    case DataVaultEntityTypes.Link:
                        newEmplacement.Entites.Add(_creationRules.First(o => o.GetType() == typeof(LinkCreationRule)).Create(entite));
                        newEmplacement.Entites.Add(_creationRules.First(o => o.GetType() == typeof(SatLinkCreationRule)).Create(entite));
                        break;
                }
            }

            return newEmplacement;
        }

        public async Task<Emplacement> CreateAsync(Emplacement source)
        {
            return Create(source);
        }
    }
}