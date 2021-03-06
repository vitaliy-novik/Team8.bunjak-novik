﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaskItem : Entity
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public TaskList List { get; set; }
    }
}
