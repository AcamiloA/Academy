
namespace Academy.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity, TEntityId> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IList<TEntity, TEntityId>, ITransaction
    {
    }
}
