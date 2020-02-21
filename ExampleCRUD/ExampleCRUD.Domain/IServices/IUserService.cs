using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ExampleCRUD.Domain.IServices
{
    public interface IUserService : IServiceBase<Domain.Entities.User>
    {
        Task<IEnumerable<Entities.User>> GetByNameOrCpfCnpj(string nameOrCpfCnpj, int page, int resultsPerPage, IDbTransaction transaction = null, int? commandTimeout = null);
    }
}
