﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalToDoItem : IDalEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public DalToDoList List { get; set; }
    }
}
