using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelisateur.Model.Extensions
{
    public static class CollectionDomainExtension
    {
        public static string UniqueName<T>(this ICollection<T> domainEntity, string name) where T : DomainEntityBase
        {
            string newName = name;
            int suffix = 0;
            while (domainEntity.Any(o => o.Name.Equals(name)))
            {
                suffix++;
                newName = $"{name}{suffix}";
            }
            return name;
        }
    }
}