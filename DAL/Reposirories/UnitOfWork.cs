using DAL.Interface.Repositories;
using System;
using System.Data.Entity;

namespace DAL.Reposirories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DbContext context;
        private IUserRepository users;
        private IToDoListRepository toDoLists;
        private IToDoItemRepository toDoItems;

        public IUserRepository Users
        {
            get
            {
                if (this.users == null)
                {
                    this.users = new UserRepository(context);
                }
                return users;
            }
        }

        public IToDoListRepository ToDoLists
        {
            get
            {
                if (this.toDoLists == null)
                {
                    this.toDoLists = new ToDoListRepository(context);
                }
                return toDoLists;
            }
        }

        public IToDoItemRepository ToDoItems
        {
            get
            {
                if (this.toDoItems == null)
                {
                    this.toDoItems = new ToDoItemRepository(context);
                }
                return toDoItems;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
