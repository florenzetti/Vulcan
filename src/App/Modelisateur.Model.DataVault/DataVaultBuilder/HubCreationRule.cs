using Modelisateur.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Modelisateur.Model.DataVault.DataVaultBuilder
{
    /// <summary>
    /// Create a new hub from a source entity
    /// </summary>
    /// <param name="source"></param>
    internal class HubCreationRule : ICreationRule<Entite, DataVaultEntity>
    {
        public DataVaultEntity Create(Entite source)
        {
            var newEntite = new Hub();
            newEntite.Name = DataVaultConvetions.PrefixedEntiteName(DataVaultEntityTypes.Hub, source.Name);
            //cle
            var cles = source.ElementsDonnees.Where(o => o.IsKey).Select(o => o.Duplicate());
            newEntite.ElementsDonnees.AddRange(cles.ToList());

            return newEntite;
        }

        public async Task<DataVaultEntity> CreateAsync(Entite source)
        {
            return Create(source);
        }
    }
}