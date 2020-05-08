using System.Linq;
using System.Threading.Tasks;

namespace Modelisateur.Model.DataVault.DataVaultBuilder
{
    internal class LinkCreationRule : ICreationRule<Entite, DataVaultEntity>
    {
        public DataVaultEntity Create(Entite source)
        {
            var newEntite = new Link();
            newEntite.Name = source.Name;
            //cle
            var cles = source.ElementsDonnees.Where(o => o.IsKey).Select(o => o.Duplicate()).ToList();
            newEntite.ElementsDonnees.AddRange(cles);

            //add liaison with linked hubs
            foreach (var liaison in source.Liaisons)
            {
                Liaison liaisonHub = new Liaison();
                liaisonHub.NameEntite = DataVaultConvetions.PrefixedEntiteName(DataVaultEntityTypes.Hub, liaison.NameEntite);
                liaisonHub.ElementsDonnees.AddRange(cles.Where(o => o.Name == liaison.NameEntite).Select(o => o.Name));
                //foreach (var elementDonnee in liaison.ElementsDonnees)
                //{
                //    liaisonHub.ElementsDonnees.Add(elementDonnee);
                //}
                newEntite.Liaisons.Add(liaisonHub);
            }

            return newEntite;
        }

        public async Task<DataVaultEntity> CreateAsync(Entite source)
        {
            return Create(source);
        }
    }
}
