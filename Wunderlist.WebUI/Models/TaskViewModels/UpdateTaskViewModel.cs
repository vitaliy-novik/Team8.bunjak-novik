using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.WebUI.Models.TaskViewModels
{
    public class UpdateTaskViewModel
    {
        public string Id { get; set; }
        public string Note { get; set; }
        public bool Completed { get; set; }
        public bool Stared { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string List { get; set; }
    }
}