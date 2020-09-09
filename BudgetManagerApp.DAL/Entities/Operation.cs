using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.DAL.Entities
{
    public class Operation
    {
        public Operation()
        {

        }
        public Operation(string typeOperation)
        {
            Type = typeOperation;
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(50)]
        public string Concept { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        [StringLength(50)]
        public string Type { get; private set; }

        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        public int? CategoryId { get; set; }


        public virtual Category Category { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
