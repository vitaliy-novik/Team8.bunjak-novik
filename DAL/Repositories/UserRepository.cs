using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using DAL.Reposirories;
using ORM.Entities;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class UserRepository : Repository<UserDTO, User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
