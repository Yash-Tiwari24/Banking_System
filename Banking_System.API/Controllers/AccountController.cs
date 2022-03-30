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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Banking_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        
        private readonly IMapper _mapper;
        public AccountController(IRepositoryManager repositoryManager, ILoggerManager loggerManager,
            IMapper mapper)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _repositoryManager = repositoryManager;
           


        }


        [HttpPost]
        [Route("register_new_account")]
        public IActionResult RegisterNewAccount([FromBody] RegisterNewAccountDto newAccount)
        {
            if (!ModelState.IsValid) return BadRequest(newAccount);
            
            var account = _mapper.Map<Account>(newAccount);
            return Ok(_repositoryManager.Account.CreateAccount(account));
        }

        [HttpGet]
        [Route("get_account_by_id")]
        public IActionResult GetAccountById(int Id)
        {
            var account = _repositoryManager.Account.GetById(Id);
            
            return Ok(new { Message = "Your Data Get Successfully", Data = account });
        }

        [HttpGet]

        [Route("get_all_accounts")]
        public IActionResult GetAllAccounts()
        {
            var allAccounts = _repositoryManager.Account.GetAllAccounts();
            
            return Ok(allAccounts);
        }

        
        [HttpGet]
        [Route("Get_By_account_number")]
        public IActionResult GetByAccountNumber(string AccountNumber)
        {
            if (!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$")) return BadRequest("Account Number Must be 10 digit");
            var account = _repositoryManager.Account.GetByAccountNumber(AccountNumber);
            return Ok(account);
        }

        [HttpPut]
        [Route("Update_Account")]
        public IActionResult UpdateAccount([FromBody] UpdateAccount model)
        {

            if (!ModelState.IsValid) return BadRequest(model);
            Account account = _repositoryManager.Account.GetById(model.Id);
             _mapper.Map(model,account);
            _repositoryManager.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("Delete_Account")]
        public IActionResult DeleteAccount(int id)
        {
            if (!ModelState.IsValid) return BadRequest(id);
            Account account = _repositoryManager.Account.GetById(id);
           
            account.Status = "Deactive";
            _repositoryManager.Save();
            
            
            return Ok("Account Deleted Successfully");


           
        }
    }
}
