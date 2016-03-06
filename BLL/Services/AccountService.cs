using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class AccountService : BaseService
    {
        /*public AccountService(IUnitOfWork uow) : base(uow)
        {
        }

        public bool Authenticate(string email, string password)
        {
            UserDTO user = _uow.Users.GetFirst(us => us.Email == email);

            if (user != null && user.Password == password)
                return true;

            return false;
        }

        public void ChangeName(Guid id, string newName)
        {
            UserDTO user = _uow.Users.GetFirst(us => us.Id == id);
            user.Name = newName;
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

        public bool Registration(User user)
        {
            UserDTO u = _uow.Users.GetFirst(us => us.Email == user.Email);

            if (user != null)
                return false;

            _uow.Users.Create(new UserDTO
            {
                Email = user.Email,
                Name = user.UserName,
                Password = user.Password
            });
            _uow.Commit();

            return true;
        }*/
    }
}
