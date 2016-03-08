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

        public void ChangeName(string id, string newName)
        {
            User user = _uow.Users.GetFirst(us => us.Id == id);
            user.UserName = newName;
            _uow.Users.Update(user);
            _uow.Commit();
        }

        public void ChangePhoto(Guid id, byte[] photo)
        {
            throw new NotImplementedException();
        }

        public Profile GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Registration(User user)
        {
            User u = _uow.Users.GetFirst(us => us.Email == user.Email);

            if (u != null)
                throw new Exception("123!");
                
            _uow.Users.Create(user);
            _uow.Commit();

            ToDoList list = new ToDoList
            {
                Name = "inbox",
                User = user
            };

            _uow.ToDoLists.Create(list);
            _uow.Commit();
        }

        public User GetByEmail(string email)
        {
            return _uow.Users.GetFirst(us => us.Email == email);
        }
    }
}
