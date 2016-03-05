using Ninject.Modules;
using Wunderlist.InterfaceRepositories;
using Wunderlist.Repositories;

namespace DependencyResolver
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
