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

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public void Post([FromBody]AddTaskViewModel value)
        {
            service.AddTask(value.Name, value.Date, value.List);
        }
    }
}
