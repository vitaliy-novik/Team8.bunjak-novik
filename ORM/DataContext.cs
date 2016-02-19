using ORM.Entities;
using System.Data.Entity;

namespace ORM
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DataContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }

    }
}
