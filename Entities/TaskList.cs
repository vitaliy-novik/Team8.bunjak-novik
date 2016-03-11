using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaskList : Entity
    {
        public TaskList()
        {
            Items = new HashSet<TaskItem>();
        }

        public string Name { get; set; }
        public virtual ICollection<TaskItem> Items { get; set; }
        public User User { get; set; }
    }
}
