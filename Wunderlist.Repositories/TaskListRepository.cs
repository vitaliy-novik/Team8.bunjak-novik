using Entities;
using System.Data.Entity;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Repositories
{
    public class TaskListRepository : Repository<TaskList>, IToDoListRepository
    {
        public TaskListRepository(DbContext context) : base(context) { }

    }
}
