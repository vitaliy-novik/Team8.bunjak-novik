﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.WebUI.Models.TaskViewModels
{
    public class AddTaskViewModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string List { get; set; }
    }
}