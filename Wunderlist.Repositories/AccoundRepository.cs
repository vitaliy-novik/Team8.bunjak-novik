using Entities;
using System.Data.Entity;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Repositories
{
    public class AccoundRepository : Repository<User>, IAccoundRepository
    {
        public AccoundRepository(DbContext context) : base(context) { }
    }
}
