using DeveloperTest.Models;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerModel[]> GetCustomersAsync();

        Task<CustomerModel> GetCustomersAsync(int id);

        Task<CustomerModel> CreateCustomerAsync(CustomerModel model);
    }
}