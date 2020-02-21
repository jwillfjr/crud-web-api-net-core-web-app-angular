using ExampleCRUD.Domain.Entities;
using ExampleCRUD.Domain.IServices;
using ExampleCRUD.Domain.IUnitOfWords;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleCRUD.Application.Services
{
    public class UserAppService : AppServiceBase<Domain.Entities.User, Domain.IServices.IUserService>, Application.IServices.IUserAppService
    {
        public UserAppService(IUserService service, IUnitOfWord unitOfWork) : base(service, unitOfWork)
        {
        }

        public virtual async Task<IEnumerable<User>> GetByNameOrCpfCnpj(string nameOrCpfCnpj, int page, int resultsPerPage)
        {
            return await _service.GetByNameOrCpfCnpj(nameOrCpfCnpj, page, resultsPerPage, _unitOfWork.Transaction);
        }
    }
}
