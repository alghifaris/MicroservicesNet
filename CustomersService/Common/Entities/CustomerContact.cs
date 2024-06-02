namespace CustomersService.Common.Entities
{
    public class CustomerContact
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string ContactType { get; set; }
        public string Value { get; set; }
        public Customer Customer { get; set; }
    }
}
