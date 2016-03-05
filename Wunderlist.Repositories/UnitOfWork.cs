﻿using EntityFrameworkContex;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.InterfaceRepositories;

namespace Wunderlist.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        
        public UnitOfWork(string connectionString)
        {
            this._context = new DataContext(connectionString);
            this.Users = new AccoundRepository(_context);
        }

        public IAccoundRepository Users { get; }
        
        public void Commit()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}