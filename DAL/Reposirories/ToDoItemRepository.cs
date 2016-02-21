using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;
using System.Data.Entity;

namespace DAL.Reposirories
{
    public class ToDoItemRepository : Repository<ToDoItemDTO, ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(DbContext context) : base(context) { }
    }
}
