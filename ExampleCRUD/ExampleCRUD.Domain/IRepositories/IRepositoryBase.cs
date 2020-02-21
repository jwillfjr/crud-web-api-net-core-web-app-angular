using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCRUD.Domain.IRepositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);

        Task<bool> Delete(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<TEntity> Get(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<IEnumerable<TEntity>> Get(object predicate, int page, int resultsPerPage, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<bool> Update(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);

    }

}
