using SafeShopping.Core.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Core.Service
{
    public interface IService<TEntity>
    {
        Task<IEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);

    }
}
