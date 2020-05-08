using Modelisation.Domain.Base;

namespace Modelisation.Domain.EmplacementAggregate
{
    public class ElementDonnee : DomainEntity
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        //public int Properties { get; private set; }
        public ElementDonnee ForeignKey { get; private set; }

        public ElementDonnee(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public void SetLiaison(ElementDonnee destination)
        {
            ForeignKey = destination;
        }
    }
}