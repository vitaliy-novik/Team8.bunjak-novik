using System;

namespace ORM.Entities
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