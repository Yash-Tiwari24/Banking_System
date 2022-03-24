using Banking_System.Model.Model;
using Banking_System.Services.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Repository.Repository
{
   public class GetUserData: IGetUserData
    {
        private readonly UserManager<Users> _userManager;
        private Users _user;
        public GetUserData(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetRoles(string userName)
        {
            _user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(_user);
            return roles.FirstOrDefault();
        }

        //Method to get email from username
        public async Task<string> GetEmail(string username)
        {
            _user = await _userManager.FindByNameAsync(username);
            var email = await _userManager.GetEmailAsync(_user);
            return email;
        }

        //Method to get all Users with role user
        public async Task<List<Users>> GetAllUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            return (List<Users>)users;
        }


        public async Task<string> GetUserId(string GuidId)
        {
            _user = await _userManager.FindByIdAsync(GuidId);
            if (_user != null)
            {
                var userid = await _userManager.GetUserIdAsync(_user);
                return userid;
            }
            else
                return null;
        }

        
    }
}
