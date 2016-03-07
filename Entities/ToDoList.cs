using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ToDoList
    {
        public ToDoList()
        {
            Id = Guid.NewGuid().ToString();
            Items = new HashSet<ToDoItem>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ToDoItem> Items { get; set; }
        public User User { get; set; }
    }
}
