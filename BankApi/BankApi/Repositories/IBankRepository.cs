using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Model;

namespace BankApi.Repositories
{
    public interface IBankRepository
    {
        Bank Create(Bank bank);
        List<Bank> Read();
        Bank Read(int id);
        Bank Update(Bank bank);
        void Delete(int id);
    }
}
