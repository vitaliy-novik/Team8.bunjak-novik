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

        public void AddTask(string email, string name, DateTime date, string listId)
        {
            var list = _uow.Users.GetFirst(u => u.Email == email)
                .ToDoLists.FirstOrDefault(l => l.Id == listId);
            var task = new ToDoItem
            {
                Name = name,
                Date = date,
                List = list
            };
            _uow.ToDoItems.Create(task);
            _uow.Commit();
        }

        public IEnumerable<ToDoList> GetAllLists(string email)
        {
            return _uow.Users.GetFirst(us => us.Email == email).ToDoLists;
        }

        public void UpdateTask(string list, ToDoItem value)
        {
            value.List = _uow.ToDoLists.GetFirst(l => l.Id == list);
            _uow.ToDoItems.Update(value);
            _uow.Commit();
        }

        public ToDoList GetList(string email, string id)
        {
            return _uow.Users.GetFirst(u => u.Email == email).
                ToDoLists.FirstOrDefault(l => l.Id == id);
        }

        public void AddList(string name, string email)
        {
            var user = _uow.Users.GetFirst(l => l.Email == email);
            var list = new ToDoList
            {
                Name = name,
                User = user
            };

            _uow.ToDoLists.Create(list);
            _uow.Commit();
        }
    }
}
