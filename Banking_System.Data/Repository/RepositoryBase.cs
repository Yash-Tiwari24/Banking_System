using Banking_System.Model.Model;
using Banking_System.Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Repository.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);
        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);
        public IQueryable<T> FindAll() => _repositoryContext.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)=> _repositoryContext.Set<T>().Where(expression);
        public void Update(T entity)=>_repositoryContext.Set<T>().Update(entity);

    }
}
