using CUMS.Gateway.IRepositories;
using CUMS.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CUMS.Gateway.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private AppDbContext context;

        public Repository(AppDbContext _context)
        {
            this.context = _context;
        }
        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
        }
        public int Rows()
        {
            return context.Set<TEntity>().ToList().Count;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllByExpression(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Where(expression).ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Where(expression).FirstOrDefault();
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public bool IsExists(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Any(expression);
        }
        public bool IsFileExists(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Any(expression);
        }
        public IEnumerable<TEntity> GetByIncludeOperation(Expression<Func<TEntity, object>> includeExpression)
        {
            return context.Set<TEntity>().Include(includeExpression);
        }

        public IEnumerable<TEntity> GetByIncludeOperationWithExpression(Expression<Func<TEntity, object>> includeExpression, Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Include(includeExpression).Where(expression);
        }
    }
}