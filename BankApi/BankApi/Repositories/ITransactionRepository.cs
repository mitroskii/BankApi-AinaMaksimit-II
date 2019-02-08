using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Model;

namespace BankApi.Repositories
{
    public interface ITransactionRepository
    {
        Transaction Create(Transaction transaction);
        List<Transaction> Read();
        Transaction Read(int id);
        Transaction Update(Transaction transaction);
        void Delete(int id);
    }
}
