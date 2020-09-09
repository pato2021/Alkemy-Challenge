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
    public class UserProfileRepository : Repository, IUserProfileRepository
    {

        public UserProfileRepository(BudgetManagerDBContext budgetManagerDBContext): base(budgetManagerDBContext)
        {

        }

        public void Add(UserProfile entity)
        {
            db.UserProfiles.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var userProfile = db.UserProfiles.Find(id);
            if (userProfile != null)
            {
                db.UserProfiles.Remove(userProfile);
                db.SaveChanges();
            }
        }

        public void Edit(UserProfile entity)
        {
            var userProfile = db.UserProfiles.FirstOrDefault(u => u.Id == entity.Id);
            userProfile.Id = entity.Id;
            userProfile.Name = entity.Name;
            userProfile.Address = entity.Address;
            userProfile.ApplicationUser = db.Users.Find(entity.ApplicationUser.Id);
            db.SaveChanges();
        }

        public IEnumerable<UserProfile> Find(Func<UserProfile, bool> predicate)
        {
            return db.UserProfiles.Where(predicate);
        }

        public UserProfile Get(int id)
        {
            return db.UserProfiles.Find(id);
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return db.UserProfiles.ToList();
        }

        public IEnumerable<Operation> ListOperationsByCategory(string idUserProfile, int idCategory)
        {
            return db.UserProfiles.Find(idUserProfile).Operations.Where(c => c.CategoryId == idCategory);
        }

        public IEnumerable<Operation> ListIncomeOperations(string idUserProfile)
        {
            return db.UserProfiles.Find(idUserProfile).Operations.Where(o => o.Type == "Income");
        }

        public IEnumerable<Operation> ListExpenseOperations(string idUserProfile)
        {
            return db.UserProfiles.Find(idUserProfile).Operations.Where(o => o.Type == "Expense");
        }


        public IEnumerable<Operation> ListTopTenOperations(string idUserProfile) 
        {
            var operations = db.UserProfiles.Find(idUserProfile).Operations.ToList();


            var topTen = operations.OrderByDescending(t => t.Id).Take(10).ToList();



            return topTen;
        }

    }
}
