namespace FinanceService.Controllers.Inputs
{
    public class IncomingPaymentInput
    {        
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }        
        public List<IncomingPaymentItemInput> IncomingPaymentItems { get; set; } = new();
    }
}
