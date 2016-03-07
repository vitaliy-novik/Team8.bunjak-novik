using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ToDoItem
    {
        public ToDoItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public ToDoList List { get; set; }
    }
}
