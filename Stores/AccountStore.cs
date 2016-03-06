using Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.InterfaceRepositories;
using Wunderlist.Services;

namespace Stores
{
    public class AccountStore : IUserStore<User>, IUserPasswordStore<User>
    {
        private AccountService _accountService; 

        public AccountStore(IUnitOfWork uow)
        {
            _accountService = new AccountService(uow);
        }

        public Task CreateAsync(User user)
        {
            IdentityResult result;
            try
            {
                _accountService.Registration(user);
                result = IdentityResult.Success;
            }
            catch (Exception ex)
            {
                result = IdentityResult.Failed(ex.Message);
            }

            return Task.FromResult<IdentityResult>(result);
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByNameAsync(string email)
        {
            User user = _accountService.GetByEmail(email);
            return Task.FromResult<User>(user);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult<string>(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult<IdentityResult>(IdentityResult.Success);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
