using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCRUD.Application.IServices
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);


        Task<bool> Delete(dynamic id)
        ;

        Task<TEntity> Get(dynamic id)
        ;

        Task<bool> Update(TEntity entity)
        ;

        Task<IEnumerable<TEntity>> Get(object predicate, int page, int resultsPerPage)
        ;

    }
}
