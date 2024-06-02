using FinanceService;
using FinanceService.Common.Entities;
using FinanceService.Controllers.CustomModels;
using FinanceService.Controllers.Inputs;
using FinanceService.Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class FinanceController : ControllerBase
{
    private readonly IIncomingPaymentService _service;

    public FinanceController(IIncomingPaymentService service)
    {
        _service = service;
    }

    [Route("GetAllIncomingPayments")]
    [HttpPost]
    public async Task<ActionResult<List<IncomingPaymentModel>>> GetAllIncomingPayments()
    {
        return await  _service.GetAllIncoming();
    }

    [Route("GetIncomingPaymentDetailById")]
    [HttpPost]
    public async Task<ActionResult<List<IncomingPaymentItemModel>>> GetIncomingPaymentDetailById(Guid id)
    {
        return await _service.GetIncomingDetailById(id);
    }

    [Route("CreateIncoming")]
    [HttpPost]
    public async Task<ActionResult<string>> CreateIncoming(IncomingPaymentInput input)
    {
        return await _service.CreateIncoming(input);
    }
}
