using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankdbContext _bankdbContext;

        public TransactionRepository(BankdbContext bankdbContext)
        {
            _bankdbContext = bankdbContext;
        }

        public Transaction Create(Transaction transaction)
        {
            _bankdbContext.Add(transaction);
            _bankdbContext.SaveChanges();
            return transaction;
        }

        public List<Transaction> Read()
        {
            return _bankdbContext.Transaction
                .AsNoTracking()
                .ToList();
        }

        public Transaction Read(int id)
        {
            return _bankdbContext.Transaction.FirstOrDefault(t => t.Id == id);
        }
    }
}
