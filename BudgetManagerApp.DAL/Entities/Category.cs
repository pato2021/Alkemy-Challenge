using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.DAL.Entities
{
    public class Category
    {
        public Category()
        {

        }
        public Category(string typeOperation)
        {
            Type = typeOperation;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Type { get; private set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
