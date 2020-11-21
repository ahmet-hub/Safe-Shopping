using SafeShopping.Core.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Core.DataAccess
{
    public interface IEntityRepositoy<TEntity>
        where TEntity: class,IEntity,new()
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);

    }
}
