using BudgetManagerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.BLL.Interfaces
{
    public interface IOperationLogic
    {
        IEnumerable<OperationDTO> GetAll();
        OperationDTO Get(int? id);
        void Add(OperationDTO operationDTO);
        void Delete(int? id);
        void Edit(OperationDTO operationDTO);
        void Categorize(int idOperation, int idCategory);
    }
}
