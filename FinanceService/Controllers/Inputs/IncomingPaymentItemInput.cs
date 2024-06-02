namespace FinanceService.Controllers.Inputs
{
    public class IncomingPaymentItemInput
    {
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
