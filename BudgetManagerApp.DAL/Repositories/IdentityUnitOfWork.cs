using BudgetManagerApp.DAL.Context;
using BudgetManagerApp.DAL.Entities;
using BudgetManagerApp.DAL.Identity;
using BudgetManagerApp.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {

        private readonly BudgetManagerDBContext db;
        private bool disposed;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new BudgetManagerDBContext(connectionString);
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            UserProfileManager = new UserProfileManager(db);
        }

        public ApplicationUserManager UserManager { get; }

        public IUserProfileManager UserProfileManager { get; }


        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    UserProfileManager.Dispose();
                }
                disposed = true;
            }
        }



    }
}
