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
    public class OperationLogic : IOperationLogic
    {

        private readonly IOperationRepository _operationRepository;

        public OperationLogic(IOperationRepository operationRepository)
        {
            this._operationRepository = operationRepository;
        }

        public void Add(OperationDTO operationDTO)
        {
            var operation = Mapper.Map<Operation>(operationDTO);
            _operationRepository.Add(operation);
        }

        public void Categorize(int idOperation, int idCategory)
        {
            _operationRepository.Categorize(idOperation,idCategory);
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("id null");
            }
            _operationRepository.Delete(id.Value);
        }

        public void Edit(OperationDTO operationDTO)
        {
            var operation = Mapper.Map<Operation>(operationDTO);
            _operationRepository.Edit(operation);
        }

        public OperationDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("id null");
            }
            var operation = _operationRepository.Get(id.Value);
            var operationDTO = Mapper.Map<OperationDTO>(operation);
            return operationDTO;
        }

        public IEnumerable<OperationDTO> GetAll()
        {
            var operations = _operationRepository.GetAll();
            var operationsDTO = Mapper.Map<IEnumerable<OperationDTO>>(operations);
            return operationsDTO;
        }
    }
}
