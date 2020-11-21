using SafeShopping.Core.DataAccess;
using SafeShopping.Core.Entitiy;
using SafeShopping.Core.Service;
using SafeShopping.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Service.Services
{
    public  class Service<TEntity> : IService<TEntity> where TEntity:class , IEntity,new()
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepositoy<TEntity> _repositoy;

        public Service(IUnitOfWork unitOfWork, IEntityRepositoy<TEntity> repositoy)
        {
          
            _unitOfWork = unitOfWork;
            _repositoy = repositoy;
        }

        public async Task<TEntity> Add(TEntity entity)
        {                      
            await _repositoy.Add(entity);
            await _unitOfWork.CommitAsync();
           return entity;        
        }
               
        public async  Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repositoy.GetAllAsync();

        }

        public async Task<IEntity> GetByIdAsync(int id)
        {
            return await _repositoy.GetByIdAsync(id);

        }

        public void Remove(TEntity entity)
        {
            _repositoy.Remove(entity);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repositoy.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            _repositoy.Update(entity);
            _unitOfWork.Commit();
            return entity;
        }
    }
}
