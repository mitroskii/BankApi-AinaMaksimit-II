using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Model;

namespace BankApp.Repositories
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        List<Customer> Read();
        Customer Read(int id);
        Customer Update(Customer customer);
        void Delete(int id);
    }
}
