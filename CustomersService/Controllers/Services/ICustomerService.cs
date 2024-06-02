using CustomersService.Common.Entities;
using CustomersService.Controllers.CustomModels;
using CustomersService.Controllers.Inputs;

namespace CustomersService.Controllers.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerContactModel>> GetCustomerContactById(Guid id);
        Task<List<CustomerModel>> GetCustomers();
        Task<CustomerModel> GetCustomerById(Guid id);
        Task<string> SaveCustomer(CustomerInput input);
        Task<string> SaveCustomerContact(CustomerContactInput input);
        Task<string> UpdateCustomer(CustomerUpdateInput input);
        Task<string> UpdateCustomerContact(CustomerContactUpdateInput input);
        Task<string> DeleteCustomer(Guid input);
        Task<string> DeleteCustomerContact(Guid input);
    }
}