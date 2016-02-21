using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;
using System.Data.Entity;

namespace DAL.Reposirories
{
    public class ToDoLisRepository : Repository<DalToDoList, ToDoList> , IToDoListRepository
    {
        public ToDoLisRepository(DbContext context) : base(context) { }        
    }
}
