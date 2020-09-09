using AutoMapper;
using BudgetManagerApp.BLL.DTO;
using BudgetManagerApp.BLL.Interfaces;
using BudgetManagerApp.DAL.Entities;
using BudgetManagerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.BLL.Logic
{
    public class UserProfileLogic : IUserProfileLogic
    {

        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileLogic(IUserProfileRepository userProfileRepository)
        {
            this._userProfileRepository = userProfileRepository;
        }

        public void Add(UserDTO userDTO)
        {
            var userProfile = Mapper.Map<UserProfile>(userDTO);
            _userProfileRepository.Add(userProfile);
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("id null");
            }
            _userProfileRepository.Delete(id.Value);
        }

        public void Edit(UserDTO userDTO)
        {
            var userProfile = Mapper.Map<UserProfile>(userDTO);
            _userProfileRepository.Edit(userProfile);
        }

        public UserDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("id null");
            }
            var userProfile = _userProfileRepository.Get(id.Value);
            var userDTO = Mapper.Map<UserDTO>(userProfile);
            return userDTO;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var usersProfile = _userProfileRepository.GetAll();
            var usersDTO = Mapper.Map<IEnumerable<UserDTO>>(usersProfile);
            return usersDTO;
        }

        public IEnumerable<OperationDTO> ListExpenseOperations(string idUserProfile)
        {
            if (idUserProfile == null)
            {
                throw new ArgumentException("id null");
            }
            var operations = _userProfileRepository.ListExpenseOperations(idUserProfile);
            var operationsDTO = Mapper.Map<IEnumerable<OperationDTO>>(operations);
            return operationsDTO;
        }

        public IEnumerable<OperationDTO> ListIncomeOperations(string idUserProfile)
        {
            if (idUserProfile == null)
            {
                throw new ArgumentException("idUserProfile null");
            }
            var operations = _userProfileRepository.ListIncomeOperations(idUserProfile);
            var operationsDTO = Mapper.Map<IEnumerable<OperationDTO>>(operations);
            return operationsDTO;
        }

        public IEnumerable<OperationDTO> ListOperationsByCategory(string idUserProfile, int? idCategory)
        {
            if ((idUserProfile == null) || (idCategory == null))
            {
                throw new ArgumentException("Null");
            }
            var operations = _userProfileRepository.ListOperationsByCategory(idUserProfile, idCategory.Value);
            var operationsDTO = Mapper.Map<IEnumerable<OperationDTO>>(operations);
            return operationsDTO;
        }

        public IEnumerable<OperationDTO> ListTopTenOperations(string idUserProfile)
        {
            if (idUserProfile == null)
            {
                throw new ArgumentException("idUserProfile null");
            }
            var operations = _userProfileRepository.ListTopTenOperations(idUserProfile);
            var operationsDTO = Mapper.Map<IEnumerable<OperationDTO>>(operations);
            return operationsDTO;
        }

    }
}
