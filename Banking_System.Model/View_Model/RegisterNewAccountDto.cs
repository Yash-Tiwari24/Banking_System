using Banking_System.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Model.View_Model
{
   public class RegisterNewAccountDto
    {
        public string UserId { get; set; }
       
        [Required(ErrorMessage = "please enter AccountType")]
        public AccountType AccountType { get; set; }
        [Required(ErrorMessage = "please enter Current Balance")]
        [Range(1000,999999,ErrorMessage ="Ensure Balance is Greater than 1000")]
        public decimal CurrentBalance { get; set;}
        public DateTime OpeningDate { get; set; }
        public DateTime DateLastUpdated { get; set; }
        [Required(ErrorMessage = "please enter BankName")]
        public string BankName { get; set; }
        [Required(ErrorMessage = "please enter BankAddress")]
        public string BankAddress { get; set; }
        [Required(ErrorMessage = "please enter status")]
        public string Status { get; set; }
    }
}
