using Banking_System.Model.Model;
using Banking_System.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Repository.Repository
{
   public class AccountRepository:RepositoryBase<Account>,IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {


        }

        public Account CreateAccount(Account account)
        {
            _repositoryContext.Accounts.Add(account);
            _repositoryContext.SaveChanges();

            return account;
        }

        public void DeleteAccount(Account account)
        {
            Delete(account);
        }

        public dynamic GetAllAccounts()
        {
            var accountById = (from u in _repositoryContext.User
                              join a in _repositoryContext.Accounts on u.Id equals a.UserId
                              select new
                              {
                                  AccountId = a.Id,
                                  UserId = u.Id,
                                  AccountNumber = a.AccountNumber,
                                  AccountType = a.AccountType,
                                  CurrentBalance = a.CurrentBalance,
                                  AccountHolderName = u.FirstName + " " + u.MiddleName + " " + u.LastName,
                                  EmailId = u.Email,
                                  MobileNumber = u.PhoneNumber,
                                  BankName = a.BankName,
                                  BankAddress = a.BankAddress,
                                  AccountOpeningDate = a.OpeningDate,
                                  Status=a.Status


                              }).ToList();


            return accountById;
        }

        public dynamic GetByAccountNumberDetail(string accountNumber)
        {
            var accountByNumber = (from u in _repositoryContext.User
                               join a in _repositoryContext.Accounts on u.Id equals a.UserId
                               where a.AccountNumber == accountNumber
                               select new
                               {
                                   AccountId = a.Id,
                                   UserId = u.Id,
                                   AccountNumber = a.AccountNumber,
                                   AccountType = a.AccountType,
                                   CurrentBalance = a.CurrentBalance,
                                   AccountHolderName = u.FirstName + " " + u.MiddleName + " " + u.LastName,
                                   EmailId = u.Email,
                                   MobileNumber = u.PhoneNumber,
                                   BankName = a.BankName,
                                   BankAddress = a.BankAddress,
                                   AccountOpeningDate = a.OpeningDate,
                                   Status = a.Status


                               }).ToList();


            return accountByNumber;
        }

        public dynamic GetByAccountIdDetail(int AccountId)
        {
            var accountById = from u in _repositoryContext.User
                              join a in _repositoryContext.Accounts on u.Id equals a.UserId
                              where a.Id== AccountId
                              select new
                              {
                                  AccountId = a.Id,
                                  UserId = u.Id,
                                  AccountNumber=a.AccountNumber,
                                  AccountType=a.AccountType,
                                  CurrentBalance=a.CurrentBalance,
                                  AccountHolderName = u.FirstName+" "+ u.MiddleName + " " + u.LastName,
                                  EmailId=u.Email,
                                  MobileNumber=u.PhoneNumber,
                                  BankName=a.BankName,
                                  BankAddress=a.BankAddress,
                                  AccountOpeningDate=a.OpeningDate,
                                  Status = a.Status


                              };

            
            return accountById;
        }

        public void UpdateAccount(Account account)
        {
            var accountToBeUpdated = _repositoryContext.Accounts.Find(account.Id);
            if (accountToBeUpdated == null) throw new ApplicationException("Account not found");
            accountToBeUpdated.DateLastUpdated = DateTime.Now;
            _repositoryContext.Accounts.Update(accountToBeUpdated);
            _repositoryContext.SaveChanges();
        }

        public Account GetById(int Id)
        {

            var account = _repositoryContext.Accounts.Where(x => x.Id == Id).FirstOrDefault();
            if (account == null)
                throw new NullReferenceException();
            return account;
        }

        public Account GetByAccountNumber(string AccountNumber)
        {
            var account = _repositoryContext.Accounts.Where(x => x.AccountNumber == AccountNumber).SingleOrDefault();
            if (account == null)
            {
                return null;
            }
            return account;
        }
    }
}
