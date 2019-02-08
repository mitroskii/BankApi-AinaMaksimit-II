using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly BankdbContext _bankdbContext;

        public BankRepository(BankdbContext bankdbContext)
        {
            _bankdbContext = bankdbContext;
        }

        public Bank Create(Bank bank)
        {
            _bankdbContext.Add(bank);
            _bankdbContext.SaveChanges();
            return bank;
        }

        public void Delete(int id)
        {
            var deleteBank = Read(id);
            _bankdbContext.Remove(deleteBank);
            _bankdbContext.SaveChanges();
            return;
        }

        public List<Bank> Read()
        {
            return _bankdbContext.Bank
                .AsNoTracking()
                .ToList();
        }

        public Bank Read(int id)
        {
            return _bankdbContext.Bank.FirstOrDefault(b => b.Id == id);
        }

        public Bank Update(Bank bank)
        {
            _bankdbContext.Update(bank);
            _bankdbContext.SaveChanges();
            return bank;
        }
    }
}
