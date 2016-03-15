using Entities;
using System.Data.Entity;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Repositories
{
    public class TaskItemRepository : Repository<TaskItem>, IToDoItemRepository
    {
        public TaskItemRepository(DbContext context) : base(context) { }

    }
}
