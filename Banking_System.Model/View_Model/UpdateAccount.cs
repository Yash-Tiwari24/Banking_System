using Banking_System.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Model.View_Model
{
   public class UpdateAccount
    {
        public int Id { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string Status { get; set; }
    }
}
