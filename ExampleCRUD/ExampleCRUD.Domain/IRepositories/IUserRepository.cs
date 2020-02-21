using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ExampleCRUD.Domain.IRepositories
{
    public interface IUserRepository : IRepositoryBase<Domain.Entities.User>
    {
        Task<IEnumerable<Entities.User>> GetByNameOrCpfCnpj(string nameOrCpfCnpj, int page, int resultsPerPage, IDbTransaction transaction = null, int? commandTimeout = null);
    }

}
