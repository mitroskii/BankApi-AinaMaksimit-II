using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Model;
using BankApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET api/transactions
        [HttpGet]
        public ActionResult<List<Transaction>> GetTransactions()
        {
            var transactions = _transactionService.Read();
            return new JsonResult(transactions);
        }

        // GET api/transactions/5
        [HttpGet("{id}")]
        public ActionResult<Transaction> Get(int id)
        {
            var transactions = _transactionService.Read(id);
            return new JsonResult(transactions);
        }

        // POST api/transactions
        [HttpPost]
        public ActionResult<Transaction> Post(Transaction transaction)
        {
            var newTransaction = _transactionService.Create(transaction);
            return new JsonResult(newTransaction);
        }
    }
}