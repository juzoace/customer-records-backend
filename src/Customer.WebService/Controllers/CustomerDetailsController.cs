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
    [Route("api/customer/{id}")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly ILogger<Customer> _logger;
        private readonly IDataRepository<Customer> _dataRepository;

        public CustomerDetailsController(ILogger<Customer> logger, IDataRepository<Customer> dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        // GET: api/Customer/5
        [HttpGet()]
        public IActionResult Get(long id)
        {
            Customer customer = _dataRepository.Get(id);

            if (customer == null)
            {
                return NotFound("The customer record couldn't be found.");
            }

            return Ok(customer);
        }

        // PUT: api/customer/5
        [HttpPut()]
        public IActionResult Put(long id, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("customer is null.");
            }

            Customer customerToUpdate = _dataRepository.Get(id);
            if (customerToUpdate == null)
            {
                return NotFound("The customer record couldn't be found.");
            }

            _dataRepository.Update(customerToUpdate, customer);
            return NoContent();
        }

        // DELETE: api/customer/5
        [HttpDelete()]
        public IActionResult Delete(long id)
        {
            Customer customer = _dataRepository.Get(id);
            if (customer == null)
            {
                return NotFound("The customer record couldn't be found.");
            }

            _dataRepository.Delete(customer);
            return NoContent();
        }
    }
}
