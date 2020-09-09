using BudgetManagerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.DAL.Interfaces
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {

        IEnumerable<Operation> ListOperationsByCategory(string idUserProfile, int idCategory);


        IEnumerable<Operation> ListIncomeOperations(string idUserProfile);


        IEnumerable<Operation> ListExpenseOperations(string idUserProfile);


        IEnumerable<Operation> ListTopTenOperations(string idUserProfile);

    }
}
