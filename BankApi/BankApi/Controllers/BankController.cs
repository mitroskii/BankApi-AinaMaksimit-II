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
    public class BankController : ControllerBase
    {
        private readonly IBankRepository _bankRepository;
        private readonly IBankService _bankService;

        public BankController(IBankRepository bankRepository, IBankService bankService)
        {
            _bankRepository = bankRepository;
            _bankService = bankService;
        }

        // GET api/banks
        [HttpGet]
        public ActionResult<List<Bank>> GetBanks()
        {
            var banks = _bankService.Read();
            return new JsonResult(banks);
        }

        // GET api/banks/5
        [HttpGet("{id}")]
        public ActionResult<Bank> Get(int id)
        {
            var customers = _bankService.Read();
            return new JsonResult(customers);
        }

        // POST api/banks
        [HttpPost]
        public ActionResult<Bank> Post(Bank bank)
        {
            var newBank = _bankService.Create(bank);
            return new JsonResult(newBank);
        }

        // PUT api/banks
        [HttpPut("{id}")]
        public ActionResult<Bank> Put(int id, Bank bank)
        {
            var updateBank = _bankService.Update(id, bank);
            return new JsonResult(updateBank);
        }

        // DELETE api/banks
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _bankService.Delete(id);
            return new OkResult();
        }
    }
}