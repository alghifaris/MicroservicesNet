namespace CustomersService.Controllers.Inputs
{
    public class CustomerContactInput
    {
            public Guid? CustomerId { get; set; }
            public string ContactType { get; set; }
            public string Value { get; set; }            
    }
}
