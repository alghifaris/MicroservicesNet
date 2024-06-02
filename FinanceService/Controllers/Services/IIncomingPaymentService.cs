using FinanceService.Controllers.CustomModels;
using FinanceService.Controllers.Inputs;

namespace FinanceService.Controllers.Services
{
    public interface IIncomingPaymentService
    {
        Task<string> CreateIncoming(IncomingPaymentInput input);
        Task<List<IncomingPaymentModel>> GetAllIncoming();
        Task<List<IncomingPaymentItemModel>> GetIncomingDetailById(Guid id);
    }
}