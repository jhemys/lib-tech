using LibTech.Domain;
using LibTech.Infrastructure.Repositories;
using LibTech.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendingMachineController : ControllerBase
    {
        private readonly VendingMachine _vendingMachine;
        private readonly IVendingMachineRepository _repository;

        public VendingMachineController(IVendingMachineRepository repository)
        {
            _vendingMachine = new VendingMachine();
            _repository = repository;
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

        [Route("[action]")]
        [HttpPost]
        public async Task AddMoney()
        {
            await _vendingMachine.InsertMoney(Money.Cent);
        }

        [Route("[action]/{position}/{value}")]
        [HttpPost]
        public async Task BuySnack(int position, int value)
        {
            var vendingMachine = await _repository.GetById(1);
            await vendingMachine.InsertMoney(new Money(0, 0, 0, value, 0, 0));
            await vendingMachine.BuyBook(position);
            await _repository.Save(vendingMachine);
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
