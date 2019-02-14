using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Model;
using BankApi.Repositories;
using BankApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET api/accounts
        [HttpGet]
        public ActionResult<List<Account>> GetAccounts()
        {
            var accounts = _accountService.Read();
            return new JsonResult(accounts);
        }

        // GET api/accounts/5
        [HttpGet("{id}")]
        public ActionResult<Account> Get(string IBAN)
        {
            var accounts = _accountService.Read(IBAN);
            return new JsonResult(accounts);
        }

        // POST api/accounts
        [HttpPost]
        public ActionResult<Account> Post(Account account)
        {
            var newAccount = _accountService.Create(account);
            return new JsonResult(newAccount);
        }

        // PUT api/accounts
        [HttpPut("{id}")]
        public ActionResult<Account> Put(string IBAN, Account account)
        {
            var updateAccount = _accountService.Update(IBAN, account);
            return new JsonResult(updateAccount);
        }

        // DELETE api/accounts
        [HttpDelete("{id}")]
        public ActionResult Delete(string IBAN)
        {
            _accountService.Delete(IBAN);
            return new OkResult();
        }
    }
}