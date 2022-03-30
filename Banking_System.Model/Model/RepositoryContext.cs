using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Model.Model
{
   public class RepositoryContext: IdentityDbContext<Users>
    {
        public RepositoryContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Users> User { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Denomination> Denominations { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }



    }
}
