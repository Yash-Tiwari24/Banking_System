using Banking_System.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Services.Services
{
    public interface IGetUserData
    {
        Task<string> GetRoles(string userName);
        Task<string> GetEmail(string username);
        Task<List<Users>> GetAllUsers();
        Task<string> GetUserId(string UserId);
    }
}
