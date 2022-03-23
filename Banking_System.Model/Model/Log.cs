using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Model.Model
{
   public class Log
    {
        [Key]
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public virtual int UserId { get; set; }
        [ForeignKey("Users")]
        public virtual Users Users { get; set; }
        public string TransactionLog { get; set; }
    }
}
