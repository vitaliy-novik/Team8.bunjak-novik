using Entities;
using System.Data.Entity;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Repositories
{
    public class ToDoListRepository : Repository<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(DbContext context) : base(context) { }

    }
}
