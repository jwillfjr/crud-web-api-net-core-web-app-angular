using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleCRUD.Application.IServices
{
    public interface IUserAppService: IAppServiceBase<Domain.Entities.User>
    {
        Task<IEnumerable<Domain.Entities.User>> GetByNameOrCpfCnpj(string nameOrCpfCnpj, int page, int resultsPerPage);
    }
}
