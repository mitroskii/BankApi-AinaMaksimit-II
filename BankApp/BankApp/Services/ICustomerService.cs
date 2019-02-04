using BankApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);
        List<Customer> Read();
        Customer Read(int id);
        Customer Update(int id, Customer customer);
        void Delete(int id);
    }
}
