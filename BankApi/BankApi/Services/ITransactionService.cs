using BankApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public interface ITransactionService
    {
        Transaction Create(Transaction transaction);
        List<Transaction> Read();
        Transaction Read(int id);
        Transaction Update(int id, Transaction transaction);
        void Delete(int id);
    }
}
