using System.Collections.Generic;

namespace Modelisateur.Model
{
    public class Entite : DomainEntityBase
    {
        public List<ElementDonnee> ElementsDonnees { get; }

        public List<Liaison> Liaisons { get; }

        public Entite()
        {
            ElementsDonnees = new List<ElementDonnee>();
            Liaisons = new List<Liaison>();
        }
    }
}