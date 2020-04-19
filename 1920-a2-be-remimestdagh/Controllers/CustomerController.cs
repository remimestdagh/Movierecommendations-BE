using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdagh.DTOs;
using BackEndRemiMestdagh.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BackEndRemiMestdagh.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet()]
        public ActionResult<CustomerDTO> GetCustomer()
        {
            Customer customer = null;
            try
            {
               customer = _customerRepository.GetByEmail(User.Identity.Name);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return new CustomerDTO(customer);
        }

        

    }
}