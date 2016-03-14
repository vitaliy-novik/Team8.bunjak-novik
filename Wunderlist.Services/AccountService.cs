using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Services
{
    public class AccountService : BaseService
    {
        public AccountService(IUnitOfWork uow) : base(uow)
        {
        }
        
        public async Task<bool> Authenticate(string email, string password)
        {
            User user = await GetByEmail(email);

            if (user != null && user.Password == password)
                return true;

            return false;
        }

        public async Task ChangeName(string email, string newName)
        {
            User user = await _uow.Users.GetFirstAsync(us => us.Email == email);
            user.UserName = newName;
            _uow.Users.Update(user);
            _uow.Commit();
        }

        public async Task Registration(User user)
        {
            User u = await _uow.Users.GetFirstAsync(us => us.Email == user.Email);

            if (u != null)
                throw new Exception("the user exists");
                
            _uow.Users.Create(user);
            _uow.Commit();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _uow.Users.GetFirstAsync(us => us.Email == email);
        }

        public async Task ChangePhoto(string email, byte[] photo)
        {
            User user = await GetByEmail(email);
            user.Photo = photo;

            _uow.Users.Update(user);
            _uow.Commit();
        }
    }
}
