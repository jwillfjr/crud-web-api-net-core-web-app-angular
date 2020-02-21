using DapperExtensions;
using DapperExtensions.Sql;
using ExampleCRUD.Domain.IDbContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCRUD.Infra.Data.DapperData.Repositories
{
    public abstract class RepositoryBase<TEntity> : Domain.IRepositories.IRepositoryBase<TEntity> where TEntity : class
    {

        DapperImplementor dapperImplementor;
        public RepositoryBase(IDbContextBase dBContext)
        {
            DbContext = dBContext;
            dapperImplementor = new DapperImplementor(
                new SqlGeneratorImpl(
                    dBContext.GetConfigurationContext<DapperExtensionsConfiguration>())
                );

            ClassMapper = dapperImplementor.SqlGenerator.Configuration.GetMap(typeof(TEntity));
        }

        protected DapperImplementor DapperImplementor { get => this.dapperImplementor; }
        protected DapperExtensions.Mapper.IClassMapper ClassMapper { get; set; }
        protected string InsertCommand { get; set; }

        protected IDbContextBase DbContext { get; set; }
        public async Task<TEntity> Add(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            try
            {
                IDbConnection? conn = null;
                if (transaction != null)
                    conn = transaction.Connection;
                else
                    conn = DbContext.Connection;


                var result = await conn.InsertAsync(entity, transaction, commandTimeout);

                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> Delete(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            try
            {
                IDbConnection conn = null;
                if (transaction != null)
                    conn = transaction.Connection;
                else
                    conn = DbContext.Connection;



                TEntity entity = await Get(id, transaction,commandTimeout);

                return await conn.DeleteAsync(entity, transaction, commandTimeout);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<TEntity> Get(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            try
            {
                IDbConnection conn = null;
                if (transaction != null)
                    conn = transaction.Connection;
                else
                    conn = DbContext.Connection;

                var result = await Task.Factory.StartNew<TEntity>(() => dapperImplementor.Get<TEntity>(conn, id, transaction, commandTimeout));

                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IEnumerable<TEntity>> Get(object predicate, int page, int resultsPerPage, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            try
            {
                IDbConnection conn = null;
                if (transaction != null)
                    conn = transaction.Connection;
                else
                    conn = DbContext.Connection;

                IList<ISort> sorts = new List<ISort> {
                new Sort
                {
                    Ascending = true,
                    PropertyName = "Id"
                }
                };

                IEnumerable<TEntity> result = await Task.Factory.StartNew(() => dapperImplementor.GetPage<TEntity>(
                    conn,
                    predicate,
                    sorts,
                    page,
                    resultsPerPage,
                    transaction,
                    commandTimeout,
                    true));

                return result;

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<bool> Update(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            try
            {
                IDbConnection conn = null;
                if (transaction != null)
                    conn = transaction.Connection;
                else
                    conn = DbContext.Connection;

                return await conn.UpdateAsync(entity, transaction, commandTimeout);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
