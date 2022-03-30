using Banking_System.Model.Model;
using Banking_System.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Repository.Repository
{
   public class RepositoryManager: IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ITransactionRepository _transactionRepository;
        private IAccountRepository _accountRepository;
        private IUserRepository _userRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IAccountRepository Account
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_repositoryContext);
                return _accountRepository;
            }
        }
        
        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);
                return _userRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

    }
}
