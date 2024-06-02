namespace FinanceService.Controllers.CustomModels
{
    public class IncomingPaymentItemModel
    {                
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
