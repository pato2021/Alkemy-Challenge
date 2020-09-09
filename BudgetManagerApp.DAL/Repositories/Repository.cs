using BudgetManagerApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.DAL.Repositories
{
    public class Repository
    {
        protected readonly BudgetManagerDBContext db;

        public Repository(BudgetManagerDBContext budgetManagerDBContext)
        {
            db = budgetManagerDBContext;
        }
    }
}
