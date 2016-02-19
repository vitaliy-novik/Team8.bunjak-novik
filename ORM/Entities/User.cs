using System;
using System.Collections.Generic;


namespace ORM.Entities
{
    public class User
    {
        public User()
        {
            ToDoLists = new HashSet<ToDoList>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<ToDoList> ToDoLists { get; set; }
    }
}
