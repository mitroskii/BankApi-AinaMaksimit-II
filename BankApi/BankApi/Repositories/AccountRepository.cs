using BankApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankdbContext _bankdbContext;

        public AccountRepository(BankdbContext bankdbContext)
        {
            _bankdbContext = bankdbContext;
        }

        public Account Create(Account account)
        {
            _bankdbContext.Add(account);
            _bankdbContext.SaveChanges();
            return account;
        }

        public void Delete(string iban)
        {
            var deleteAccount = Read(iban);
            _bankdbContext.Remove(deleteAccount);
            _bankdbContext.SaveChanges();
            return;
        }

        public List<Account> Read()
        {
            return _bankdbContext.Account
                .AsNoTracking()
                .ToList();
        }

        public Account Read(string iban)
        {
            return _bankdbContext.Account.FirstOrDefault(a => a.IBAN == iban);
        }

        public Account Update(Account account)
        {
            _bankdbContext.Update(account);
            _bankdbContext.SaveChanges();
            return account;
        }
    }
}
