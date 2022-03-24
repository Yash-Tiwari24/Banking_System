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
    }
}
