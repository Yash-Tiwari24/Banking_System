﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Services.Services
{
   public interface IRepositoryManager
    {
        IAccountRepository Account { get; }
        ITransactionRepository Transaction { get; }
        IUserRepository User { get; }
    }
}
