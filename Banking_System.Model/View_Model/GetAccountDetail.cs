using Banking_System.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Model.View_Model
{
    public class GetAccountDetail
    {
        public GetUser getUser { get; set; }
        public Account getAccount { get; set; }
        public IEnumerable<Transaction> Transactions {get;set;}
                                      
    }
}
