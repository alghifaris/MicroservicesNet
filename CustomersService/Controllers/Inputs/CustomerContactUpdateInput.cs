namespace CustomersService.Controllers.Inputs
{
    public class CustomerContactUpdateInput
    {
        public Guid Id { get; set; }
        public string ContactType { get; set; }
        public string Value { get; set; }
    }
}
