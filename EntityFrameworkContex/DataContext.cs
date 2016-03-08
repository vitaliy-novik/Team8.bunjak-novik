using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
