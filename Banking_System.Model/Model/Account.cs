using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Model.Model
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
       
        public virtual string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        [Required(ErrorMessage = "please enter AccountType")]
        public AccountType AccountType { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime OpeningDate { get; set; }
        [Required(ErrorMessage = "please enter BankName")]
        public string BankName { get; set; }
        [Required(ErrorMessage = "please enter BankAddress")]
        public string BankAddress { get; set; }
        public DateTime DateLastUpdated { get; set; }
        [StringLength(20, MinimumLength = 4)]
        [Required(ErrorMessage = "please enter Status")]
        public string Status { get; set; }
        
        Random rand = new Random();
        public Account()
        {
            AccountNumber = Convert.ToString((long)Math.Floor(rand.NextDouble() * 9_000_000_000L + 1_000_000_000L));
            //9_000_000_000 so we could get a 10-digit random account number
            AccountHolderName = $"{Users.FirstName} {Users.MiddleName} {Users.LastName}";
        }
    }
    public enum AccountType
    {
        Saving,//Saving=>0,Current=>1,Salary=>2
        Current,
        Salary
    }
}
