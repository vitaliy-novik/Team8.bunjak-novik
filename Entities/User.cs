﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : Entity, IUser
    {
        public User()
        {
            ToDoLists = new HashSet<ToDoList>();
        }
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public virtual ICollection<ToDoList> ToDoLists { get; set; }

    }
}
