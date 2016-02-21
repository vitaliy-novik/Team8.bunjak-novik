using System;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IAccountService
    {
        bool Registeration(User user);
        bool Authendicate(string email, string password);
        Profile GetProfile(Guid id);
        void ChangePhoto(Guid id, byte[] photo);
        void ChangeName(Guid id, string newName);
    }
}
