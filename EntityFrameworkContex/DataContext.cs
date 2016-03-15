using Entities;
using System.Data.Entity;

namespace EntityFrameworkContex
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
