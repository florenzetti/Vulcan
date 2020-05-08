using Modelisation.Domain.Base;

namespace Modelisation.Domain.AggregatesModel.ProviderAggregate
{
    public class Provider : DomainEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public IProviderHandler Handler { get; private set; }

        public Provider(string name, IProviderHandler handler)
        {
            Name = name;
            Handler = handler;
        }

        public Provider UseHandler<T>(T handler) where T : IProviderHandler
        {
            Handler = handler;
            return this;
        }
    }
}