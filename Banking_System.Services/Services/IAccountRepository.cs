using Banking_System.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Services.Services
{
   public interface IAccountRepository
    {
        dynamic GetAllAccounts();
        Account CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
        dynamic GetByAccountIdDetail(int AccountId);
        dynamic GetByAccountNumberDetail(string AccountNumber);
        Account GetById(int Id);
        Account GetByAccountNumber(string AccountNumber);
    }
}
