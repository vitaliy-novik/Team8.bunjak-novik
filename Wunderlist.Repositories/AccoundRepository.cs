using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Repositories
{
    public class AccoundRepository : Repository<User>, IAccoundRepository
    {
        public AccoundRepository(DbContext context) : base(context) { }
    }
}
