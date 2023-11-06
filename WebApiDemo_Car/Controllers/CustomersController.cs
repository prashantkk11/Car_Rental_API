using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo_Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return Customer.GetAllCustomers();
        }

        // GET api/Customers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = Customer.GetSingleCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/Customers
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            Customer.InsertCustomer(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
        }

        // PUT api/Customers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (customer == null || customer.CustomerId != id)
            {
                return BadRequest();
            }

            Customer.UpdateCustomer(customer);
            return NoContent();
        }

        // DELETE api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer.DeleteCustomer(id);
            return NoContent();
        }
    }

}
