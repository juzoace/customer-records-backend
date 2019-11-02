using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCRUD.WebService.Models;
using CustomerCRUD.WebService.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerCRUD.WebService.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<Customer> _logger;
        private readonly IDataRepository<Customer> _dataRepository;
        public CustomerController(ILogger<Customer> logger, IDataRepository<Customer> dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        // GET: api/Customer
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Customer> customers = _dataRepository.GetAll();
            return Ok(customers);
        }

        // POST: api/customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("customer is null.");
            }

            _dataRepository.Add(customer);
            return CreatedAtRoute(
                  "Get",
                  new { Id = customer.CustomerId },
                  customer);
        }
    }
}
