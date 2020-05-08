using Modelisation.Domain.Base;
using System.Threading.Tasks;

namespace Modelisation.Domain.EmplacementAggregate
{
    public interface IEmplacementRepository : IRepository<Solution>
    {
        Emplacement Add(Emplacement solution);
        Emplacement Update(Emplacement solution);
        Task<Emplacement> FindAsync(string id);
    }
}