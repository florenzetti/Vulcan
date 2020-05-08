using Modelisateur.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Modelisateur.Services.DataVaultBuilder
{
    /// <summary>
    /// Create a new hub from a source entity
    /// </summary>
    /// <param name="source"></param>
    public class HubCreationRule : ICreationRule<Entite, Entite>
    {
        public Entite Create(Entite source)
        {
            var newEntite = new Entite();
            newEntite.Name = $"Hub{source.Name}";
            //cle
            var cles = source.ElementsDonnees.Where(o => o.IsKey).Select(o => o.Duplicate());
            newEntite.ElementsDonnees.AddRange(cles.ToList());

            return newEntite;
        }

        public async Task<Entite> CreateAsync(Entite source)
        {
            return Create(source);
        }
    }
}