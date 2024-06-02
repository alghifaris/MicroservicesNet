namespace CustomersService.Controllers.Inputs
{
    public class CustomerInput
    {        
        public string Name { get; set; }
        public CustomerAddressInput Address { get; set; }
        public List<CustomerContactInput> Contacts { get; set; } = new();
    }
}
