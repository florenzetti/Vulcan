using Modelisation.Domain.Base;
using System.Collections.Generic;

namespace Modelisation.Domain.EmplacementAggregate
{
    public class Solution : DomainEntity, IAggregateRoot
    {
        public string Identity { get; private set; }
        public string Name { get; private set; }

        private List<Emplacement> _emplacements;

        public IEnumerable<Emplacement> Emplacements => _emplacements.AsReadOnly();

        protected Solution()
        {
            _emplacements = new List<Emplacement>();
        }

        public Solution(string identity, string name) : this()
        {
            //TODO : règles de validations des proprietés
            Identity = identity;
            Name = name;
        }

        public Emplacement AddEmplacement(string name)
        {
            var emplacement = new Emplacement(name);

            _emplacements.Add(emplacement);

            //TODO: Add domain event emplacementAdded

            return emplacement;
        }
    }
}
