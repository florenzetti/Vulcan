using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisation.Domain.AggregatesModel.ProviderAggregate
{
    public interface IProviderHandler
    {
        IProviderResult Execute();
    }
}
