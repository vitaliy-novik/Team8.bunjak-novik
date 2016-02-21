using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;
using System.Data.Entity;

namespace DAL.Reposirories
{
    public class UserRepository : Repository<DalUser, User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
