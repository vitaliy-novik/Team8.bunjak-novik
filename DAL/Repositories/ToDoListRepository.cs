using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ToDoListRepository : Repository<ToDoListDTO, ToDoList> , IToDoListRepository
    {
        public ToDoListRepository(DbContext context) : base(context) { }        
    }
}
