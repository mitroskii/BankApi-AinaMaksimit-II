using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Model;
using BankApi.Repositories;

namespace BankApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Create(Customer customer)
        {
            return _customerRepository.Create(customer);
        }

        public List<Customer> Read()
        {
            return _customerRepository.Read();
        }

        public Customer Read(int id)
        {
            return _customerRepository.Read(id);
        }

        public Customer Update(int id, Customer customer)
        {
            var updateCustomer = _customerRepository.Read(id);
            if (updateCustomer == null)
            {
                throw new Exception("Customer not found!");
            }
            else
            {
                return _customerRepository.Update(customer);
            }
        }

        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }
    }
}
