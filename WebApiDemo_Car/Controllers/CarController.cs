using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo_Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Car.GetAll();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return Car.GetSingleCar(id);
            //return "value";
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            Car.InsertCar(value);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car value)
        {
            Car.UpdateCar(value);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Car.DeleteCar(id);
        }
    }
}
