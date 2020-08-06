using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeveloperTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var customers = await _customerService.GetCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var customer = await _customerService.GetCustomersAsync(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomerModel model)
        {
            var customer = await _customerService.CreateCustomerAsync(model);
            return Created($"customer/{ customer.Id }", customer);
        }
    }
}