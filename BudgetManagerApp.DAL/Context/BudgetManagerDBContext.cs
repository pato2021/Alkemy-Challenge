using BudgetManagerApp.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.DAL.Context
{
    public class BudgetManagerDBContext : IdentityDbContext<ApplicationUser>
    {

        //Inicialiacion diferida para optimizacion
        private static readonly Lazy<BudgetManagerDBContext> _lazyBudgetManagerDBContext = new Lazy<BudgetManagerDBContext>(() => new BudgetManagerDBContext());


        public BudgetManagerDBContext() : base("BudgetManagerConnection")
        {
        }


        public BudgetManagerDBContext(string conectionString) : base(conectionString)
        {
        }


        public static BudgetManagerDBContext BudgetManagerInstance => _lazyBudgetManagerDBContext.Value;


        public DbSet<Category> Categories { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
