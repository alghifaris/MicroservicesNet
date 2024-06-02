namespace CustomersService.Common.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CustomerAddress Address { get; set; }
        public List<CustomerContact> Contacts { get; set; }
    }
}
