using BankApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public interface IAccountService
    {
        Account Create(Account account);
        List<Account> Read();
        Account Read(string IBAN);
        Account Update(string IBAN, Account account);
        void Delete(string IBAN);
    }
}
