using LibTech.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendingMachineController : ControllerBase
    {
        public readonly VendingMachine _vendingMachine;

        public VendingMachineController()
        {
            _vendingMachine = new VendingMachine();
        }

        // GET: api/<SnackMachineController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SnackMachineController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SnackMachineController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [Route("api/[controller]/AddMoney")]
        [HttpPost]
        public void AddMoney()
        {
            _vendingMachine.InsertMoney(Money.Cent);
        }

        // PUT api/<SnackMachineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SnackMachineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
