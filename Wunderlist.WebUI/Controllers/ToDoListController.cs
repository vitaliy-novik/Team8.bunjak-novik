using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
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

        public IHttpActionResult Get()
        {
            var a = service.GetAllLists(User.Identity.Name).ToArray();
            return Ok(a.Select(b => new
            {
                id = b.Id,
                name = b.Name
            }).ToArray());
            
        }

        public IHttpActionResult Get(string id)
        {
            var r = service.GetList(User.Identity.Name, id);
            return Ok(r.Items.Select(i => new
            {
                id = i.Id,
                name = i.Name,
                completed = i.IsCompleted,
                date = i.Date,
                List = r.Id
            }
            ));
        }

        public void Delete(string id)
        {
            service.Delete(id);
        }

        public void Put([FromBody]EditListViewModel value)
        {
            service.Update(new ToDoList { Id = value.Id, Name = value.Name});
        }

        public void Post([FromBody]AddListViewModel value)
        {
            service.AddList(value.Name, User.Identity.Name);
        }
    }
}
