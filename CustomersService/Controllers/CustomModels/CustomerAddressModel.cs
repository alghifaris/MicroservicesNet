namespace CustomersService.Controllers.CustomModels
{
    public class CustomerAddressModel
    {
            public Guid CustomerId { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Province { get; set; }                    
    }
}
