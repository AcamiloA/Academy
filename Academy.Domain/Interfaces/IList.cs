using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Interfaces
{
    public interface IList<TEntity, TEntityId>
    {
        List<TEntity> GetList();
        TEntity GetEntity(TEntityId entityID);
    }
}
