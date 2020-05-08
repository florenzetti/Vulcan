using Modelisation.Domain.Base;
using System.Collections.Generic;

namespace Modelisation.Domain.EmplacementAggregate
{
    public class Entite : DomainEntity
    {
        public string Name { get; private set; }

        private List<ElementDonnee> _elementsDonnees;

        public IEnumerable<ElementDonnee> ElementsDonnees => _elementsDonnees.AsReadOnly();
        protected Entite()
        {
            _elementsDonnees = new List<ElementDonnee>();
        }

        public Entite(string name) : this()
        {
            Name = name;
        }

        public ElementDonnee AddElementDonnee(string name, string type)
        {
            var elementDonnee = new ElementDonnee(name, type);

            _elementsDonnees.Add(elementDonnee);
            //TODO : add domain event ElementDonneeAdded

            return elementDonnee;
        }
    }
}