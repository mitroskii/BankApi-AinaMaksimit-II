using BankApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Repositories
{
    public interface IAccountRepository
    {
        Account Create(Account account);
        List<Account> Read();
        Account Read(string iban);
        Account Update(Account account);
        void Delete(string iban);
    }
}
