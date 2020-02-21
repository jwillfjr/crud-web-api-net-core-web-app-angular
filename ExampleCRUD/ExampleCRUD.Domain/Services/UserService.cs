using ExampleCRUD.Domain.Entities;
using ExampleCRUD.Domain.IRepositories;
using ExampleCRUD.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ExampleCRUD.Domain.Services
{
    public class UserService : ServiceBase<Domain.Entities.User, IUserRepository>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public async Task<IEnumerable<User>> GetByNameOrCpfCnpj(string nameOrCpfCnpj, int page, int resultsPerPage, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return await Repository.GetByNameOrCpfCnpj(nameOrCpfCnpj, page, resultsPerPage, transaction, commandTimeout);
        }
    }
}
