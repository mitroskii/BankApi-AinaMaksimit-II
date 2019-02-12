using BankApi.Model;
using BankApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Transaction Create(Transaction transaction)
        {
            return _transactionRepository.Create(transaction);
        }

        public List<Transaction> Read()
        {
            return _transactionRepository.Read();
        }

        public Transaction Read(int id)
        {
            return _transactionRepository.Read(id);
        }

        public Transaction Update(int id, Transaction transaction)
        {
            var updateTransaction = _transactionRepository.Read(id);
            if (updateTransaction == null)
            {
                throw new Exception("Transaction not found!");
            }
            else
            {
                return _transactionRepository.Update(transaction);
            }
        }

        public void Delete(int id)
        {
            _transactionRepository.Delete(id);
        }
    }
}
