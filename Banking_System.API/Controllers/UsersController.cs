using AutoMapper;
using Banking_System.Model.Model;
using Banking_System.Model.View_Model;
using Banking_System.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly UserManager<Users> _userManager;
        private readonly IGetUserData _getUserData;
        private readonly IMapper _mapper;
        public UsersController(IRepositoryManager repositoryManager, ILoggerManager loggerManager,
            IMapper mapper, UserManager<Users> userManager,
           IGetUserData getUserData)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
            _userManager = userManager;
            _getUserData = getUserData;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _repositoryManager.User.GetAllUsers();
                var usersDto = _mapper.Map<IEnumerable<GetUser>>(users);
                return Ok(usersDto);
            }
            catch(Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the { nameof(GetAllUsers)}action {ex}");
                return StatusCode(500, "Internal Server Error");
            }

        }
        [HttpGet("Role")]
        public async Task<IActionResult> GetUserRole(string Username)
        {
            var role = await _getUserData.GetRoles(Username);
            return Ok(role);
        }


        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(string Id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);
                var userEntity = _mapper.Map<GetUser>(user);
                return Ok(userEntity);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the { nameof(GetByUserId)}action {ex}");
                return StatusCode(404, "User Not Found");
            }
        }

        [HttpGet("GetByUserName")]
        public async Task<IActionResult> GetByUserName(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                var userEntity = _mapper.Map<GetUser>(user);
                return Ok(userEntity);

            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the { nameof(GetByUserName)}action {ex}");
                return StatusCode(404, "User Not Found");
            }
           
        }

        [HttpPost("Customer_Registration")]
        public async Task<IActionResult> CustomerRegistration([FromBody] RegisterUsersDto newUser)
        {
            var user = _mapper.Map<Users>(newUser);
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRoleAsync(user, "Customer");
            return Ok("Customer Created");
        }

        [HttpPost("Employee _Registration")]
        public async Task<IActionResult> EmployeeRegistration([FromBody] RegisterUsersDto newUser)
        {
            var user = _mapper.Map<Users>(newUser);
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRoleAsync(user, "Employee");
            return Ok("Employee Created");
        }

        [HttpPost("Admin_Registration")]
        public async Task<IActionResult> AdminRegistration([FromBody] RegisterUsersDto newUser)
        {
            var user = _mapper.Map<Users>(newUser);
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return Ok("Admin Created");
        }


        [HttpPut]
        [Route("Update_User")]
        public async Task<IActionResult> UpdateUser(string username, [FromBody] UpdateUserDto updateUser)
        {
            var user =await _userManager.FindByNameAsync(username) ;
            user.FirstName = updateUser.FirstName;
            user.MiddleName = updateUser.MiddleName;
            user.LastName = updateUser.LastName;
            user.DOB = updateUser.DOB;
            user.Email = updateUser.Email;
            user.Status = updateUser.Status;
            user.PhoneNumber = updateUser.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok("User Profile Updated Successfully");
        }

        [HttpDelete]
        [Route("Delete_User")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            user.Status = "Deactive";
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok("User Deleted Successfully");
        }
    }
}
