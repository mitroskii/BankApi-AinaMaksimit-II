﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Model;
using BankApp.Repositories;
using BankApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
            private readonly ICustomerRepository _customerRepository;
            private readonly ICustomerService _customerService;

            public CustomersController(ICustomerRepository customerRepository, ICustomerService customerService)
            {
                _customerRepository = customerRepository;
                _customerService = customerService;
            }

            // GET api/persons
            [HttpGet]
            public ActionResult<List<Customer>> GetCustomers()
            {
                var customers = _customerService.Read();
                return new JsonResult(customers);
            }

            // GET api/persons/5
            [HttpGet("{id}")]
            public ActionResult<Customer> Get(int id)
            {
                var customers = _customerService.Read();
                return new JsonResult(customers);
            }

            // POST api/persons
            [HttpPost]
            public ActionResult<Customer> Post(Customer customer)
            {
                var newCustomer = _customerService.Create(customer);
                return new JsonResult(newCustomer);
            }

            // PUT api/persons
            [HttpPut("{id}")]
            public ActionResult<Customer> Put(int id, Customer customer)
            {
                var updateCustomer = _customerService.Update(id, customer);
                return new JsonResult(updateCustomer);
            }

            // DELETE api/persons
            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                _customerService.Delete(id);
                return new OkResult();
            }
    }
}