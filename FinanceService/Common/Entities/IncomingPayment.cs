namespace FinanceService.Common.Entities
{
    public class IncomingPayment
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public decimal TotalPayment { get; set; }
        public DateTime PaymentDate { get; set; }
        public ICollection<IncomingPaymentItem> IncomingPaymentItems { get; set; }
    }
}
