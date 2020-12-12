using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SafeShopping.Core.DataAccess;
using SafeShopping.Core.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepositoy<TEntity>
        where TEntity:class,IEntity,new()
    {
        public readonly DbContext _dbContext;
        public readonly DbSet<TEntity> _dbSet;

        public EfEntityRepositoryBase(SafeShoppingContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> Add(TEntity entity)
        {
             await _dbSet.AddAsync(entity);
             return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
           
        }
        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
