namespace Modelisateur.Model
{
    /// <summary>
    /// Defines the creator of domain entities in a specific infrastructure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface ICreator<in T, out TResult> where T : DomainEntityBase
    {
        TResult Create(T entity);
    }
}