using BudgetManagerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.BLL.Interfaces
{
    public interface IUserProfileLogic
    {
        IEnumerable<UserDTO> GetAll();

        UserDTO Get(int? id);

        void Add(UserDTO userDTO);

        void Delete(int? id);

        void Edit(UserDTO userDTO);

        IEnumerable<OperationDTO> ListOperationsByCategory(string idUserProfile, int? idCategory);


        IEnumerable<OperationDTO> ListIncomeOperations(string idUserProfile);


        IEnumerable<OperationDTO> ListExpenseOperations(string idUserProfile);


        IEnumerable<OperationDTO> ListTopTenOperations(string idUserProfile);
    }
}
