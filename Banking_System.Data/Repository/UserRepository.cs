using Banking_System.Model.Model;
using Banking_System.Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Repository.Repository
{
   public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        private RepositoryContext _dbContext;
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
           
        }
       
        public IEnumerable<Users> GetAllUsers() =>
          FindAll().OrderBy(u => u.FirstName).ToList();

       
        public void CreateUser(Users users)
        {
            Create(users);
        }

        public void DeleteUser(Users user)
        {
           Delete(user);
        }


        public void UpdateUser(Users user)
        {
           Update(user);
        }

        public Users GetById(string username)
        {
            
            return FindByCondition(u => u.UserName.Equals(username)).SingleOrDefault();

        }
    }
}
