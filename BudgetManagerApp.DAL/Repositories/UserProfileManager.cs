using BudgetManagerApp.DAL.Context;
using BudgetManagerApp.DAL.Entities;
using BudgetManagerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.DAL.Repositories
{
    public class UserProfileManager : IUserProfileManager
    {
        public BudgetManagerDBContext Database { get; set; }
        public UserProfileManager(BudgetManagerDBContext db)
        {
            Database = db;
        }

        public void Create(UserProfile item)
        {
            Database.UserProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
