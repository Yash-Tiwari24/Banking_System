using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Model.Model
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string TransactionUniqueReference { get; set; }
        [Required]
        [RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$", ErrorMessage = "Enter Transaction Amount")]
        public decimal TransactionAmount { get; set; }
        public TranStatus TransactionStatus { get; set; }
        public bool IsSuccessful => TransactionStatus.Equals(TranStatus.Success); //depends on the value of transactin status
        [Required]
        [RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$", ErrorMessage = "Account Number must be 10-digit")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage ="Enter Transaction Detail")]
        public string TransactionParticulars { get; set; }
        public TranType TransactionType { get; set; } 
        
        public DateTime TransactionDate { get; set; }
        public Transaction()
        {
            TransactionUniqueReference = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 27)}";
        }
    }

    public enum TranStatus
    {
        Failed,
        Success,
        Error
    }
    public enum TranType
    {
        Deposit,
        Withdraw
    }
}
