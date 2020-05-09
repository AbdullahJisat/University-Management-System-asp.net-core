using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CUMS.Gateway.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        int Rows();
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllByExpression(Expression<Func<TEntity, bool>> expression);
        TEntity GetById(int id);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        bool IsExists(Expression<Func<TEntity, bool>> expression);
        bool IsFileExists(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetByIncludeOperation(Expression<Func<TEntity, object>> includeExpression);
        IEnumerable<TEntity> GetByIncludeOperationWithExpression(Expression<Func<TEntity, object>> includeExpression,
            Expression<Func<TEntity, bool>> expression);
    }
}