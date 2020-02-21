using DapperExtensions;
using ExampleCRUD.Domain.Entities;
using ExampleCRUD.Domain.IDbContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ExampleCRUD.Infra.Data.DapperData.Repositories
{
    public class UserRepository : RepositoryBase<Domain.Entities.User>, Domain.IRepositories.IUserRepository
    {
        public UserRepository(IDbContextBase dBContext) : base(dBContext)
        {
        }

        public async Task<IEnumerable<User>> GetByNameOrCpfCnpj(string nameOrCpfCnpj, int page, int resultsPerPage, IDbTransaction transaction = null, int? commandTimeout = null)
        {

            try
            {
                var predicates = Predicates.Group(GroupOperator.Or,
                    Predicates.Field<User>(u => u.Name, Operator.Like, nameOrCpfCnpj),
                    Predicates.Field<User>(u => u.CpfCnpj, Operator.Like, nameOrCpfCnpj));

                IDbConnection conn = null;
                
                if (transaction != null)
                    conn = transaction.Connection;
                else
                    conn = DbContext.Connection;

                IList<ISort> sorts = new List<ISort> {
                    Predicates.Sort<User>(u=>u.Name),
                    Predicates.Sort<User>(u=>u.CpfCnpj)
                };

                IEnumerable<User> result = await Task.Run(() => DapperImplementor.GetPage<User>(
                    conn,
                    predicates,
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
    }
}
