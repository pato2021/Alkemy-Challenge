using BudgetManagerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.BLL.Interfaces
{
    public interface ICategoryLogic
    {
        IEnumerable<CategoryDTO> GetAll();

        CategoryDTO Get(int? id);

        void Add(CategoryDTO categoryDTO);

        void Delete(int? id);

        void Edit(CategoryDTO categoryDTO);

        IEnumerable<CategoryDTO> GetCategoriesByType(string typeCategory);

        

    }
}
