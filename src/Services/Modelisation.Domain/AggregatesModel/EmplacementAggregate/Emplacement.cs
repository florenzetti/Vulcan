using Modelisation.Domain.Base;
using System.Collections.Generic;

namespace Modelisation.Domain.EmplacementAggregate
{
    public class Emplacement : DomainEntity
    {
        public string Name { get; private set; }

        private List<Entite> _entites;

        public IEnumerable<Entite> Entites => _entites.AsReadOnly();

        protected Emplacement()
        {
            _entites = new List<Entite>();
        }

        public Emplacement(string name) : this()
        {
            Name = name;
        }

        public Entite AddEntite(string name)
        {
            var entite = new Entite(name);
            _entites.Add(entite);

            //TODO: add domain event entiteAdded

            return entite;
        }
    }
}