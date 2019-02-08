using BankApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankdbContext _bankdbContext;

        public CustomerRepository(BankdbContext bankdbContext)
        {
            _bankdbContext = bankdbContext;
        }

        public Customer Create(Customer customer)
        {
            _bankdbContext.Add(customer);
            _bankdbContext.SaveChanges();
            return customer;
        }

        public void Delete(int id)
        {
            var deleteCustomer = Read(id);
            _bankdbContext.Remove(deleteCustomer);
            _bankdbContext.SaveChanges();
            return;
        }

        public List<Customer> Read()
        {
            return _bankdbContext.Customer
                .AsNoTracking()
                .Include(a => a.Account)
                .ToList();
        }

        public Customer Read(int id)
        {
            return _bankdbContext.Customer.FirstOrDefault(c => c.Id == id);
        }

        public Customer Update(Customer customer)
        {
            _bankdbContext.Update(customer);
            _bankdbContext.SaveChanges();
            return customer;
        }
    }
}
