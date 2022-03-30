using AutoMapper;
using Banking_System.Services.Services;
using Microsoft.AspNetCore.Http;
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
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionService;
        private readonly ILoggerManager _loggerManager;
        private IMapper _mapper;
        public TransactionsController(ITransactionRepository transactionService, ILoggerManager loggerManager,
            IMapper mapper)
        {
            _transactionService = transactionService;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Make_Deposit")]
        public IActionResult MakeDeposit(string AccountNumber, decimal Amount)
        {
            if (!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$")) return BadRequest("Account Number Must be 10 digit");

            return Ok(_transactionService.MakeDeposit(AccountNumber, Amount));
        }

        [HttpPost]
        [Route("Make_Withdrawal")]
        public IActionResult MakeWithdrawal(string AccountNumber, decimal Amount)
        {
            //try check validity of accountNumber
            if (!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$")) return BadRequest("Your Account Number can only be 10 digits");

            return Ok(_transactionService.MakeWithdrawal(AccountNumber, Amount));

        }
        
        [HttpGet]
        [Route("Find_By_Date_Transaction")]
        public IActionResult FindByDate(DateTime dateTime)
        {
            var account = _transactionService.FindTransactionByDate(dateTime);
            return Ok(new { Message = "Your Data Get Successfully", Data = account });
        }
        [HttpGet]
        [Route("Find_By_Date_Range_Transaction")]
        public IActionResult FindByDateRange(DateTime startDate,DateTime endDate)
        {
            var account = _transactionService.FindTransactionByDateRange(startDate,endDate);
            return Ok(new { Message = "Your Data Get Successfully", Data = account });
        }

        [HttpGet]
        [Route("Find_By_Date_Range_Transaction_Deatil")]
        public IActionResult FindTransactionByDateRangeDetail(string AccountNumber, DateTime startDate, DateTime endDate)
        {
            var account = _transactionService.FindTransactionByDateRangeDetail(AccountNumber, startDate, endDate);
            return Ok(new { Message = "Your Data Get Successfully", Data = account });
        }
    }
}
