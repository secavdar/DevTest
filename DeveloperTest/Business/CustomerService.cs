using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerModel[]> GetCustomersAsync()
        {
            return await _context.Customers.Select(x => new CustomerModel
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type
            }).ToArrayAsync();
        }

        public async Task<CustomerModel> GetCustomersAsync(int id)
        {
            return await _context.Customers.Where(x => x.Id == id).Select(x => new CustomerModel
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type
            }).SingleOrDefaultAsync();
        }

        public async Task<CustomerModel> CreateCustomerAsync(CustomerModel model)
        {
            var addedCustomer = _context.Customers.Add(new Customer
            {
                Name = model.Name,
                Type = model.Type
            });

            await _context.SaveChangesAsync();

            return new CustomerModel
            {
                Id = addedCustomer.Entity.Id,
                Name = addedCustomer.Entity.Name,
                Type = addedCustomer.Entity.Type
            };
        }
    }
}
