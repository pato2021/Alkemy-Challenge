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
    public class CategoryRepository : Repository, ICategoryRepository
    {

        public CategoryRepository(BudgetManagerDBContext budgetManagerDBContext): base(budgetManagerDBContext)
        {

        }

        public void Add(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        public void Edit(Category entity)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == entity.Id);
            category.Id = entity.Id;
            category.Name = entity.Name;
            db.SaveChanges();
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return db.Categories.Where(predicate);
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories.ToList<Category>();
        }

        public IEnumerable<Category> GetCategoriesByType(string typeCategory)
        {
            return Find(c => c.Type == typeCategory);
        }
    }
}
