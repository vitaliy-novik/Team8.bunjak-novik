using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using DAL.Interface;

namespace BLL.Service
{
    public class AccountService : IAccountService
    {
        IRepository<UserDTO> users;

        public AccountService(IRepository<UserDTO> userRep)
        {
            users = userRep;
        }

        public bool Authendicate(string email, string password)
        {
            UserDTO user = users.GetFirst(us => us.Email == email);

            if (user != null && user.Password == password)
                return true;

            return false;
        }

        public void ChangeName(Guid id, string newName)
        {
            UserDTO user = users.GetFirst(us => us.Id == id);
            user.Name = newName;
            users.Update(user);
            //TODO save all
        }

        public void ChangePhoto(Guid id, byte[] photo)
        {
            throw new NotImplementedException();
        }

        public Profile GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Registeration(User user)
        {
            UserDTO u = users.GetFirst(us => us.Email == user.Email);

            if (user != null)
                return false;
            
            users.Create(new UserDTO
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password
            });
            //TODO save all

            return true;
        }
    }
}
