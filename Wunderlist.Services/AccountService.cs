using Entities;
using System;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Services
{
    public class AccountService : BaseService
    {
        public AccountService(IUnitOfWork uow) : base(uow)
        {
        }
        
        public bool Authenticate(string email, string password)
        {
            User user = GetByEmail(email);

            if (user != null && user.Password == password)
                return true;

            return false;
        }

        public void ChangeName(string email, string newName)
        {
            User user = _uow.Users.GetFirst(us => us.Email == email);
            user.UserName = newName;
            _uow.Users.Update(user);
            _uow.Commit();
        }

        public void Registration(User user)
        {
            User u = _uow.Users.GetFirst(us => us.Email == user.Email);

            if (u != null)
                throw new Exception("the user exists");
                
            _uow.Users.Create(user);
            _uow.Commit();
        }

        public User GetByEmail(string email)
        {
            return _uow.Users.GetFirst(us => us.Email == email);
        }

        public void ChangePhoto(string email, byte[] photo)
        {
            User user = GetByEmail(email);
            user.Photo = photo;

            _uow.Users.Update(user);
            _uow.Commit();
        }
    }
}
