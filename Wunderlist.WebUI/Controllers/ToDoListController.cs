using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Wunderlist.InterfaceRepositories;
using Wunderlist.Repositories;
using Wunderlist.Services;
using Wunderlist.WebUI.Models.ListViewModels;

namespace Wunderlist.WebUI.Controllers
{
    public class ToDoListController : ApiController
    {
        TaskService service;

        public ToDoListController()
        {
            IUnitOfWork uow = new UnitOfWork("DefaultConnection");
            service = new TaskService(uow);
        }

        public IEnumerable<ToDoList> Get()
        {
            return service.GetAllLists(User.Identity.Name);
        }

        public ToDoList Get(string id)
        {
            return service.GetList(User.Identity.Name, id);
        }

        public void Post([FromBody]AddListViewModel value)
        {
            
            service.AddList(value.Name, User.Identity.Name);
        }
    }
}
