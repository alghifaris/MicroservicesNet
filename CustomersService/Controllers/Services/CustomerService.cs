using CustomersService.Common.Entities;
using CustomersService.Controllers.CustomModels;
using CustomersService.Controllers.Inputs;
using Microsoft.EntityFrameworkCore;

namespace CustomersService.Controllers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CustomerContactModel>> GetCustomerContactById(Guid id)
        {
            var data = await (from cc in _dbContext.CustomerContacts
                              where cc.CustomerId == id
                              select new CustomerContactModel { Id=cc.Id, ContactType = cc.ContactType, Value = cc.Value }).ToListAsync();
            return data;
        }
        public async Task<List<CustomerModel>> GetCustomers()
        {
            var data = await (from c in _dbContext.Customers
                              join ca in _dbContext.CustomerAddresses on c.Id equals ca.CustomerId
                              select new CustomerModel
                              {
                                  Id = c.Id,
                                  Name = c.Name,
                                  Address = ca.Address,
                                  City = ca.City,
                                  Province = ca.Province
                              }).ToListAsync();

            return data;
        }
        public async Task<CustomerModel> GetCustomerById(Guid Id)
        {
            var data = await (from c in _dbContext.Customers
                              join ca in _dbContext.CustomerAddresses on c.Id equals ca.CustomerId
                              select new CustomerModel
                              {
                                  Id = c.Id,
                                  Name = c.Name,
                                  Address = ca.Address,
                                  City = ca.City,
                                  Province = ca.Province
                              }).FirstOrDefaultAsync(w => w.Id == Id);

            return data;
        }
        public async Task<string> SaveCustomer(CustomerInput input)
        {
            var result = "Data customer has been created";
            var data = new Customer()
            {
                Name = input.Name,

            };

            var dataAddress = new CustomerAddress()
            {
                Address = input.Address.Address,
                City = input.Address.City,
                Province = input.Address.Province
            };

            data.Address = dataAddress;
            List<CustomerContact> listContact = new List<CustomerContact>();
            foreach (var contact in input.Contacts)
            {
                var dataContact = new CustomerContact()
                {
                    ContactType = contact.ContactType,
                    Value = contact.Value
                };

                listContact.Add(dataContact);
            }
            data.Contacts = listContact;


            _dbContext.Customers.Add(data);
            await _dbContext.SaveChangesAsync();

            return result;
        }
        public async Task<string> SaveCustomerContact(CustomerContactInput input)
        {
            var result = "Data customer contact has been created";
            var data = await _dbContext.Customers.Include(cc=>cc.Contacts).FirstOrDefaultAsync(w => w.Id == input.CustomerId);

            var dataContact = new CustomerContact()
            {
                CustomerId = input.CustomerId ?? Guid.Empty,
                ContactType = input.ContactType,
                Value = input.Value
            };

            data.Contacts.Add(dataContact);

            _dbContext.Customers.Update(data);
            await _dbContext.SaveChangesAsync();

            return result;
        }
        public async Task<string> UpdateCustomer(CustomerUpdateInput input)
        {
            var result = "Data customer has been updated";
            var dataCustomerUpdate = await _dbContext.Customers.Include(ca => ca.Address).FirstOrDefaultAsync(w => w.Id == input.Id);
            dataCustomerUpdate.Name = input.Name;
            dataCustomerUpdate.Address.City = input.Address.City;
            dataCustomerUpdate.Address.Province = input.Address.Province;
            dataCustomerUpdate.Address.Address = input.Address.Address;


            _dbContext.Customers.Update(dataCustomerUpdate);
            await _dbContext.SaveChangesAsync();

            return result;
        }
        public async Task<string> UpdateCustomerContact(CustomerContactUpdateInput input){
            var result = "Data customer contact has been updated";
            var dataCustomerContact = await _dbContext.CustomerContacts.FirstOrDefaultAsync(w => w.Id == input.Id);
            dataCustomerContact.ContactType = input.ContactType;
            dataCustomerContact.Value = input.Value;

            _dbContext.CustomerContacts.Update(dataCustomerContact);
            await _dbContext.SaveChangesAsync();
            return result;
        }
        public async Task<string> DeleteCustomer(Guid id)
        {
            var result = "Data customer has been deleted";
            var dataCustomerUpdate = await _dbContext.Customers.Include(ca => ca.Address).Include(cc=>cc.Contacts).FirstOrDefaultAsync(w => w.Id == id);
            _dbContext.Customers.Remove(dataCustomerUpdate);
            await _dbContext.SaveChangesAsync();

            return result;
        }
        public async Task<string> DeleteCustomerContact(Guid id)
        {
            var result = "Data customer contact has been deleted";
            var dataCustomerContact = await _dbContext.CustomerContacts.FirstOrDefaultAsync(w => w.Id == id);            

            _dbContext.CustomerContacts.Remove(dataCustomerContact);
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
