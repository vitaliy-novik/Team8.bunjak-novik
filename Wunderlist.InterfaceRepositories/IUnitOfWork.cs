using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.InterfaceRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAccoundRepository Users { get; }
        IToDoItemRepository ToDoItems { get; }
        IToDoListRepository ToDoLists { get; }
        //...

        void Commit();
    }
}
