namespace FinanceService.Controllers.CustomModels
{
    public class IncomingPaymentModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public decimal TotalPayment { get; set; }
        public DateTime PaymentDate { get; set; }        
    }
}
