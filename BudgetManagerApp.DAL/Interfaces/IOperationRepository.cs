﻿using BudgetManagerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.DAL.Interfaces
{
    public interface IOperationRepository : IRepository<Operation>
    {
        void Categorize(int idOperation, int idCategory);
    }
}