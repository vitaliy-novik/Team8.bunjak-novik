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
        //...

        void Commit();
    }
}
