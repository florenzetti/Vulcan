using System.Linq;
using System.Threading.Tasks;
using Modelisateur.Model;
using Modelisateur.Model.Extensions;

namespace Modelisateur.Model.DataVault.DataVaultBuilder
{

    /// <summary>
    /// Create a new satellite from a source entity
    /// </summary>
    internal class SatelliteCreationRule : ICreationRule<Entite, DataVaultEntity>
    {
        SourceEntityCategorisationRule _categorisationRule;

        public SatelliteCreationRule()
        {
            _categorisationRule = new SourceEntityCategorisationRule();
        }

        public DataVaultEntity Create(Entite source)
        {
            var newEntite = new Satellite();
            newEntite.Name = DataVaultConvetions.PrefixedEntiteName(DataVaultEntityTypes.Satellite, source.Name);

            //add liaison with linked hub
            var cles = source.ElementsDonnees.Where(o => o.IsKey).Select(o => o.Duplicate()).ToList();
            if (cles.Count > 0)
            {
                Liaison liaisonHub = new Liaison();
                var sourceType = _categorisationRule.Categorise(source);
                liaisonHub.NameEntite = DataVaultConvetions.PrefixedEntiteName(sourceType, source.Name);
                foreach (var cle in cles)
                {
                    liaisonHub.ElementsDonnees.Add(cle.Name);
                }
                newEntite.Liaisons.Add(liaisonHub);
                newEntite.ElementsDonnees.AddRange(cles);
            }

            var attributs = source.ElementsDonnees.Where(o => !o.IsKey).Select(o => o.Duplicate());
            newEntite.ElementsDonnees.AddRange(attributs.ToList());

            string nameFinVersion = newEntite.ElementsDonnees.UniqueName("DtFinVersion");
            newEntite.ElementsDonnees.Add(new ElementDonnee() { Name = nameFinVersion, Type = "datetime" });

            return newEntite;
        }

        public async Task<DataVaultEntity> CreateAsync(Entite source)
        {
            return Create(source);
        }
    }
}