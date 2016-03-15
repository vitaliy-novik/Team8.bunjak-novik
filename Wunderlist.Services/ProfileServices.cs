using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Services
{
    public class ProfileServices : BaseService
    {
        public ProfileServices(IUnitOfWork uow) : base(uow)
        {
        }


    }
}
