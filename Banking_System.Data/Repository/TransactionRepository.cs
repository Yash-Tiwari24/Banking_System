using AutoMapper;
using Banking_System.Model.Model;
using Banking_System.Services.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Repository.Repository
{
   public class TransactionRepository : ITransactionRepository
    {
        private readonly IMapper _mapper;
        private RepositoryContext _repositoryContext;
        private ILogger<TransactionRepository> _logger;
        private IAccountRepository _accountService;
        public TransactionRepository(RepositoryContext repositoryContext, IAccountRepository accountService,
          ILogger<TransactionRepository> logger, IMapper mapper) 
        {
            _repositoryContext = repositoryContext;
            _logger = logger;
            _accountService = accountService;
            _mapper = mapper;
        }

        public Response FindTransactionByDate(DateTime date)
        {
            Response response = new Response();
            var transaction = _repositoryContext.Transactions.Where(x => x.TransactionDate == date).ToList();
            response.ResponseCode = "00";
            response.ResponseMessage = "Transaction created successfully!";
            response.Data = transaction;
            return response;
        }

        public Response FindTransactionByDateRange(DateTime startDate, DateTime endDate)
        {

            Response response = new Response();
            var transaction = _repositoryContext.Transactions.Where(x => x.TransactionDate >= startDate && x.TransactionDate<=endDate).ToList();
            response.ResponseCode = "00";
            response.ResponseMessage = "Transaction created successfully!";
            response.Data = transaction;
            return response;
        }

        public dynamic FindTransactionByDateRangeDetail(string AccountNumber, DateTime startDate, DateTime endDate)
        {
            var query = from t in _repositoryContext.Transactions.ToList()
                        where t.TransactionDate >= startDate && t.TransactionDate <= endDate
                        group t by t.AccountNumber into at
                        join a in _repositoryContext.Accounts.ToList() on at.Key equals a.AccountNumber
                        join u in _repositoryContext.User.ToList() on  a.UserId equals u.Id
                        where a.AccountNumber == AccountNumber
                        
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
                            Status = a.Status,
                            Transactions =at
                        };



            //var accountByNumber = (from u in _repositoryContext.User
            //                       join a in _repositoryContext.Accounts on u.Id equals a.UserId
            //                       join t in _repositoryContext.Transactions on a.AccountNumber equals t.AccountNumber
            //                       where a.AccountNumber == AccountNumber
            //                       where t.TransactionDate >= startDate && t.TransactionDate <=endDate
            //                       select new
            //                       {
            //                           AccountId = a.Id,
            //                           UserId = u.Id,
            //                           AccountNumber = a.AccountNumber,
            //                           AccountType = a.AccountType,
            //                           CurrentBalance = a.CurrentBalance,
            //                           AccountHolderName = u.FirstName + " " + u.MiddleName + " " + u.LastName,
            //                           EmailId = u.Email,
            //                           MobileNumber = u.PhoneNumber,
            //                           BankName = a.BankName,
            //                           BankAddress = a.BankAddress,
            //                           AccountOpeningDate = a.OpeningDate,
            //                           Status = a.Status,
            //                           TransactionDate=t.TransactionDate,
            //                           TransactionAmount=t.TransactionAmount
                                       

            //                       }).ToList();

            return query;

        }

        public Response MakeDeposit(string AccountNumber, decimal Amount)
        {
            Response response = new Response();
            Account depositAccount;
            Transaction transaction = new Transaction();
            try
            {

                depositAccount = _accountService.GetByAccountNumber(AccountNumber);
                if (depositAccount == null)
                    throw new NullReferenceException("Account Does Not Exit");
                if (depositAccount.Status == "Deactive")
                    throw new ArgumentException("Account Does Not Exist");
                depositAccount.CurrentBalance += Amount;
                if ((_repositoryContext.Entry(depositAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
                {
                    //so transaction is successful
                    transaction.TransactionStatus = TranStatus.Success;
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Transaction Successful!";
                    response.Data = null;

                }
                else
                {
                    //so transaction is not successful
                    transaction.TransactionStatus = TranStatus.Failed;
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Transaction Failed!";
                    response.Data = null;
                }
            }
            catch(ArgumentException ex)
            {
                transaction.TransactionStatus = TranStatus.Failed;
                response.ResponseCode = "404";
                response.ResponseMessage = "Account is deactive";
                response.Data = null;
                _logger.LogError(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                transaction.TransactionStatus = TranStatus.Failed;
                response.ResponseCode = "404";
                response.ResponseMessage = "Account Does Not Exist";
                response.Data = null;
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {

                _logger.LogError($"ERROR OCCURRED => MESSAGE: {ex.Message}");
            }
            transaction.TransactionDate = DateTime.Now.Date;
            transaction.TransactionType = TranType.Deposit;
            transaction.TransactionAmount = Amount;
            transaction.AccountNumber = AccountNumber;
            transaction.TransactionParticulars = $"NEW Transaction Sucessfully Credited TO Account => {JsonConvert.SerializeObject(transaction.AccountNumber)} ON {transaction.TransactionDate} TRAN_TYPE =>  {transaction.TransactionType} TRAN_STATUS => {transaction.TransactionStatus}";

            _repositoryContext.Transactions.Add(transaction);
            _repositoryContext.SaveChanges();
            return response;
        }

        public Response MakeWithdrawal(string AccountNumber, decimal Amount)
        {
            Response response = new Response();
            Account withdrawAccount;

            Transaction transaction = new Transaction();
            try
            {
                withdrawAccount = _accountService.GetByAccountNumber(AccountNumber);
                if (withdrawAccount == null)
                    throw new NullReferenceException("Account Does Not Exit");
                if (withdrawAccount.Status == "Deactive")
                    throw new ArgumentException("Account is deactive");
                withdrawAccount.CurrentBalance -= Amount;
                if ((_repositoryContext.Entry(withdrawAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
                {
                    
                    transaction.TransactionStatus = TranStatus.Success;
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Transaction Successful!";
                    response.Data = null;

                }
                else
                {
                   
                    transaction.TransactionStatus = TranStatus.Failed;
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Transaction Failed!";
                    response.Data = null;
                }
            }
            catch (NullReferenceException ex)
            {
                transaction.TransactionStatus = TranStatus.Failed;
                response.ResponseCode = "404";
                response.ResponseMessage = "Account Does Not Exist";
                response.Data = null;
                _logger.LogError(ex.Message);
            }
            catch (ArgumentException ex)
            {
                transaction.TransactionStatus = TranStatus.Failed;
                response.ResponseCode = "404";
                response.ResponseMessage = "Account is Deactive";
                response.Data = null;
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {

                _logger.LogError($"ERROR OCCURRED => MESSAGE: {ex.Message}");
            }
            transaction.TransactionDate = DateTime.Now.Date;
            transaction.TransactionType = TranType.Withdraw;
            transaction.TransactionAmount = Amount;
            transaction.AccountNumber = AccountNumber;
            transaction.TransactionParticulars = $"NEW Transaction Sucessfully Withdraw TO Account => {JsonConvert.SerializeObject(transaction.AccountNumber)} ON {transaction.TransactionDate} TRAN_TYPE =>  {transaction.TransactionType} TRAN_STATUS => {transaction.TransactionStatus}";

            _repositoryContext.Transactions.Add(transaction);
            _repositoryContext.SaveChanges();
            return response;
        }
    }
}
