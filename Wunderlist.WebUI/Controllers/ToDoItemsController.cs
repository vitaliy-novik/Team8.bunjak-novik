using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wunderlist.InterfaceRepositories;
using Wunderlist.Repositories;
using Wunderlist.Services;
using Wunderlist.WebUI.Models.TaskViewModels;

namespace Wunderlist.WebUI.Controllers
{
    public class ToDoItemsController : ApiController
    {
        TaskService service;

        public ToDoItemsController()
        {
            IUnitOfWork uow = new UnitOfWork("DefaultConnection");
            service = new TaskService(uow);
        }

        public void Post([FromBody]AddTaskViewModel value)
        {
            string userName = User.Identity.Name;
            service.AddTask(userName, value.Name, DateTime.Now, value.List);
        }

        public void Put(string id, [FromBody]UpdateTaskViewModel value)
        {
            ToDoItem item = new ToDoItem
            {
                Id = id,
                IsCompleted = value.Completed,
                Name = value.Name,
                Note = value.Note,
                Date = value.Date
            };
            service.UpdateTask(value.List, item);
        }
    }
}
