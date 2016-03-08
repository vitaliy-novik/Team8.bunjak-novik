using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Services
{
    public class TaskService : BaseService
    {
        public TaskService(IUnitOfWork uow) : base(uow) { }

        public void AddTask(string name, DateTime date, string list)
        {
            var li = _uow.ToDoLists.GetFirst(l => l.Name == list);
            var i = new ToDoItem
            {
                Name = name,
                Date = date,
                List = li,
                IsCompleted = false,
                Note = null
            };
            _uow.ToDoItems.Create(i);
            _uow.Commit();
        }
    }
}
