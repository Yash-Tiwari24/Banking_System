using Banking_System.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Services.Services
{
   public interface ITransactionRepository
    {
        Response FindTransactionByDate(DateTime date);
        Response MakeDeposit(string AccountNumber, decimal Amount);
        Response MakeWithdrawal(string AccountNumber, decimal Amount);
        Response FindTransactionByDateRange(DateTime startDate,DateTime endDate);
        dynamic FindTransactionByDateRangeDetail(string AccountNumber,DateTime startDate, DateTime endDate);
    }
}
