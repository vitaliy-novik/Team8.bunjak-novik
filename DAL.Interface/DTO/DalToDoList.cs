using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalToDoList : IDalEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DalUser User { get; set; }
    }
}
