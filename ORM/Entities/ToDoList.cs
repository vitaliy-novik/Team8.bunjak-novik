using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class ToDoList
    {
        public ToDoList()
        {
            Id = Guid.NewGuid();
            Items = new HashSet<ToDoItem>();
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public virtual ICollection<ToDoItem> Items { get; set; }
        public User User { get; set; }
    }
}
