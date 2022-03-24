using Banking_System.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Services.Services
{
   public interface IUserRepository
    {
        public IEnumerable<Users> GetAllUsers();
        Users GetById(string username);
        void CreateUser(Users user);
        void DeleteUser(Users user);
        void UpdateUser(Users user);



    }
}
