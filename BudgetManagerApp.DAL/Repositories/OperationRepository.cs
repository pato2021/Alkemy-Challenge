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
    public class OperationRepository : Repository, IOperationRepository
    {

        public OperationRepository(BudgetManagerDBContext budgetManagerDBContext) : base(budgetManagerDBContext)
        {

        }

        public void Add(Operation entity)
        {
            //Por simplicidad se establece la fecha en base al orden de llegada
            //entity.Date = DateTime.Now;
            db.Operations.Add(entity);
            db.SaveChanges();
        }

        public void Categorize(int idOperation, int idCategory)
        {
            var operation = db.Operations.Find(idOperation);
            var category = db.Categories.Find(idCategory);
            operation.CategoryId = category.Id;
            operation.Category = category;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var operation = db.Operations.Find(id);
            if (operation != null)
            {
                db.Operations.Remove(operation);
                db.SaveChanges();
            }
        }

        public void Edit(Operation entity)
        {
            var operation = db.Operations.FirstOrDefault(o => o.Id == entity.Id);

            operation.Concept = entity.Concept;
            operation.Amount = entity.Amount;
            operation.Date = entity.Date;


            db.SaveChanges();
        }

        public IEnumerable<Operation> Find(Func<Operation, bool> predicate)
        {
            return db.Operations.Where(predicate);
        }

        public Operation Get(int id)
        {
            return db.Operations.Find(id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return db.Operations.ToList();
        }

    }
}
