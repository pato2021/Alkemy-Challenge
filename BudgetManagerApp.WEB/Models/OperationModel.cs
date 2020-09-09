using BudgetManagerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetManagerApp.WEB.Models
{
    public class OperationModel
    {
        public OperationModel()
        {

        }
        public OperationModel(string typeOperation)
        {
            Type = typeOperation;
        }

        public int Id { get; set; }

        [Required]
        public string Concept { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }


        [DisplayFormat(NullDisplayText = "No Type")]
        public string Type { get; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual UserProfile User { get; set; }
    }
}