using Academy.Domain.Interfaces;

namespace Academy.Application.Interfaces
{
    public interface IBaseService<TEntity, TEntityId> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IList<TEntity, TEntityId>
    {
    }
}
