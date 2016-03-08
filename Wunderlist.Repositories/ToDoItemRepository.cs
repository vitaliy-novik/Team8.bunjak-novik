using Entities;
using System.Data.Entity;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Repositories
{
    public class ToDoItemRepository : Repository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(DbContext context) : base(context) { }

    }
}
