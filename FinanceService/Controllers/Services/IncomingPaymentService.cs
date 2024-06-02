using FinanceService.Common.Entities;
using FinanceService.Controllers.CustomModels;
using FinanceService.Controllers.Inputs;
using Microsoft.EntityFrameworkCore;

namespace FinanceService.Controllers.Services
{

    public class IncomingPaymentService : IIncomingPaymentService
    {
        private readonly ApplicationDbContext _dbContext;
        public IncomingPaymentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<IncomingPaymentModel>> GetAllIncoming()
        {
            var data = await( from ip in _dbContext.IncomingPayments                       
                       select new IncomingPaymentModel
                       {
                           Id = ip.Id,
                           CustomerName = ip.CustomerName,
                           CustomerContact = ip.CustomerContact,
                           TotalPayment = ip.TotalPayment,
                           PaymentDate = ip.PaymentDate                        
                       }).ToListAsync();
            return data;
        }

        public async Task<List<IncomingPaymentItemModel>> GetIncomingDetailById(Guid id)
        {
            var data = await(from ipi in _dbContext.IncomingPaymentItems
                       where ipi.IncomingPaymentId == id
                       select new IncomingPaymentItemModel
                       {
                           UnitId = ipi.UnitId,
                           UnitName = ipi.UnitName,
                           UnitPrice = ipi.UnitPrice
                       }).ToListAsync();
            return data;
        }

        public async Task<string> CreateIncoming(IncomingPaymentInput input)
        {
            var result = "Data incoming has been created";

            var data = new IncomingPayment()
            {
                CustomerId = input.CustomerId,
                CustomerName = input.CustomerName,
                CustomerContact = input.CustomerContact,
                PaymentDate = DateTime.Now.Date,

            };
            decimal totalPayment = 0;
            List<IncomingPaymentItem> dataItems = new List<IncomingPaymentItem>();
            foreach (var items in input.IncomingPaymentItems)
            {
                var dataItem = new IncomingPaymentItem()
                {
                    UnitId = items.UnitId,
                    UnitName = items.UnitName,
                    UnitPrice = items.UnitPrice
                };
                totalPayment += items.UnitPrice;
                dataItems.Add(dataItem);
            };

            data.TotalPayment = totalPayment;
            data.IncomingPaymentItems = dataItems;

            _dbContext.IncomingPayments.Add(data);
            await _dbContext.SaveChangesAsync();

            return result;

        }
    }
}
