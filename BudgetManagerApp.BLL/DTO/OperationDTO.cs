using BudgetManagerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.BLL.DTO
{
    public class OperationDTO
    {

        public OperationDTO()
        {

        }
        public OperationDTO(string typeOperation)
        {
            Type = typeOperation;
        }

        public int Id { get; set; }

        public string Concept { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; }

        public string UserId { get; set; }
 
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
