using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Model;
using BankApi.Repositories;
using BankApi.Services;
using BankApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
            private readonly ICustomerService _customerService;

            public CustomersController(ICustomerService customerService)
            {
                _customerService = customerService;
            }

        // GET api/customers
        [HttpGet]
            public ActionResult<List<Customer>> GetCustomers()
            {
                var customers = _customerService.Read();
                return new JsonResult(customers);
            }

            // GET api/customers/5
            [HttpGet("{id}")]
            public ActionResult<Customer> Get(int id)
            {
                var customers = _customerService.Read();
                return new JsonResult(customers);
            }

            // POST api/customers
            [HttpPost]
            public ActionResult<Customer> Post(Customer customer)
            {
                var newCustomer = _customerService.Create(customer);
                return new JsonResult(newCustomer);
            }

            // PUT api/customers
            [HttpPut("{id}")]
            public ActionResult<Customer> Put(int id, Customer customer)
            {
                var updateCustomer = _customerService.Update(id, customer);
                return new JsonResult(updateCustomer);
            }

            // DELETE api/customers
            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                _customerService.Delete(id);
                return new OkResult();
            }
    }
}