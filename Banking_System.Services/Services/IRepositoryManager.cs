using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Services.Services
{
   public interface IRepositoryManager
    {
        IAccountRepository Account { get; }
       
        IUserRepository User { get; }
        Task SaveAsync();
        void Save();
    }
}
