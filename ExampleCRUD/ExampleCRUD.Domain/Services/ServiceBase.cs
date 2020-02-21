using ExampleCRUD.Domain.IRepositories;
using ExampleCRUD.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCRUD.Domain.Services
{
    public class ServiceBase<TEntity, TIRepositoryBase> : IServiceBase<TEntity>
        where TEntity : class
        where TIRepositoryBase : IRepositoryBase<TEntity>
    {
        public ServiceBase(TIRepositoryBase repository)
        {
            Repository = repository;
        }

        protected TIRepositoryBase Repository { get; private set; }

        public Type GetIRepositoryType()
        {
            return typeof(TIRepositoryBase);
        }

        public virtual async Task<TEntity> Add(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await Repository.Add(entity, transaction, commandTimeout);
        }

        public virtual async Task<bool> Delete(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await Repository.Delete(id, transaction, commandTimeout);
        }

        public virtual async Task<TEntity> Get(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await Repository.Get(id, transaction, commandTimeout);
        }


        public virtual async Task<bool> Update(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await Repository.Update(entity, transaction, commandTimeout);
        }

        public virtual async Task<IEnumerable<TEntity>> Get(object predicate, int page, int resultsPerPage, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await Repository.Get(predicate, page, resultsPerPage, transaction, commandTimeout);
        }
    }
}
