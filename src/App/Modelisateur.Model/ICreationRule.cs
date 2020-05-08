using System.Threading.Tasks;

namespace Modelisateur.Model
{
    /// <summary>
    /// Defines a rule to create a domain entity
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public interface ICreationRule<in TInput, TOutput> 
        where TInput : DomainEntityBase
        where TOutput : DomainEntityBase
    {
        TOutput Create(TInput source);
        Task<TOutput> CreateAsync(TInput source);
    }

    public interface ICreationRule : ICreationRule<DomainEntityBase, DomainEntityBase>
    { }
}
