namespace CustomersService.Controllers.Inputs
{
    public class CustomerUpdateInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CustomerAddressInput Address { get; set; }        
    }
}
