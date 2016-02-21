using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using DAL.Reposirories;
using ORM.Entities;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ToDoItemRepository : Repository<ToDoItemDTO, ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(DbContext context) : base(context) { }
    }
}
