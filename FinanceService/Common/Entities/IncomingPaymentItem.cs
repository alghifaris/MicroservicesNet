namespace FinanceService.Common.Entities
{
    public class IncomingPaymentItem
    {
        public Guid Id { get; set; }
        public Guid IncomingPaymentId { get; set; }
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal UnitPrice { get; set; }
        public IncomingPayment IncomingPayment { get; set; }
    }
}
