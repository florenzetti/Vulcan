using Modelisation.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisation.Domain.AggregatesModel.ProviderAggregate
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Provider Add(Provider provider);
    }
}
