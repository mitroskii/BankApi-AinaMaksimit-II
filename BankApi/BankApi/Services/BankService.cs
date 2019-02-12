using BankApi.Model;
using BankApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public Bank Create(Bank bank)
        {
            return _bankRepository.Create(bank);
        }

        public List<Bank> Read()
        {
            return _bankRepository.Read();
        }

        public Bank Read(int id)
        {
            return _bankRepository.Read(id);
        }

        public Bank Update(int id, Bank bank)
        {
            var updateBank = _bankRepository.Read(id);
            if (updateBank == null)
            {
                throw new Exception("Bank not found!");
            }
            else
            {
                return _bankRepository.Update(bank);
            }
        }

        public void Delete(int id)
        {
            _bankRepository.Delete(id);
        }
    }
}
