using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : IUser
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            ToDoLists = new HashSet<ToDoList>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<ToDoList> ToDoLists { get; set; }

    }
}
