namespace CustomersService.Common.Entities
{
    public class CustomerAddress
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public Customer Customer { get; set; }
    }

}
