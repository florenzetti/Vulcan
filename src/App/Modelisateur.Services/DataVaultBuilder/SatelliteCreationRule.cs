using System.Linq;
using System.Threading.Tasks;
using Modelisateur.Model;
using Modelisateur.Model.Extensions;

namespace Modelisateur.Services.DataVaultBuilder
{

    /// <summary>
    /// Create a new satellite from a source entity
    /// </summary>
    public class SatelliteCreationRule : ICreationRule<Entite, Entite>
    {
        //private Entite _linkedHub;
        //public SatelliteCreationRule(Entite linkedHub)
        //{
        //    _linkedHub = linkedHub;
        //}
        public Entite Create(Entite source)
        {
            var newEntite = new Entite();
            newEntite.Name = $"Sat{source.Name}";

            //add liaison with linked hub
            var cles = source.ElementsDonnees.Where(o => o.IsKey).Select(o => o.Duplicate()).ToList();
            if (cles.Count > 0)
            {
                Liaison liaisonHub = new Liaison();
                liaisonHub.NameEntite = $"Hub{source.Name}";
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

        public async Task<Entite> CreateAsync(Entite source)
        {
            return Create(source);
        }
    }
}