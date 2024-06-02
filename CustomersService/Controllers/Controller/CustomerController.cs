using CustomersService;
using CustomersService.Common.Entities;
using CustomersService.Controllers.CustomModels;
using CustomersService.Controllers.Inputs;
using CustomersService.Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomersController(ICustomerService service)
    {
        _service = service;
    }

    [Route("GetCustomers")]
    [HttpPost]
    public async Task<ActionResult<List<CustomerModel>>> GetCustomers(
        )
    {
        return await _service.GetCustomers();
    }

    [Route("GetCustomerById")]
    [HttpPost]
    public async Task<ActionResult<CustomerModel>> GetCustomerById(Guid id
       )
    {
        return await _service.GetCustomerById(id);
    }

    [Route("GetCustomerContactById")]
    [HttpPost]
    public async Task<ActionResult<List<CustomerContactModel>>> GetCustomerContactById(Guid id)
    {
        return await _service.GetCustomerContactById(id);
    }

    [Route("CreateCustomer")]
    [HttpPost]
    public async Task<ActionResult<string>> CreateCustomer(CustomerInput input)
    {
        string data = await _service.SaveCustomer(input);
        return data;
    }
    [Route("CreateCustomerContact")]
    [HttpPost]
    public async Task<ActionResult<string>> CreateCustomerContact(CustomerContactInput input)
    {
        string data = await _service.SaveCustomerContact(input);
        return data;
    }
    [Route("UpdateCustomer")]
    [HttpPost]
    public async Task<ActionResult<string>> UpdateCustomer(CustomerUpdateInput input)
    {
        string data = await _service.UpdateCustomer(input);
        return data;
    }
    [Route("UpdateCustomerContact")]
    [HttpPost]
    public async Task<ActionResult<string>> UpdateCustomerContact(CustomerContactUpdateInput input)
    {
        string data = await _service.UpdateCustomerContact(input);
        return data;
    }
    [Route("DeleteCustomer")]
    [HttpPost]
    public async Task<ActionResult<string>> DeleteCustomer(Guid id)
    {
        string data = await _service.DeleteCustomer(id);
        return data;
    }
    [Route("DeleteCustomerContact")]
    [HttpPost]
    public async Task<ActionResult<string>> DeleteCustomerContact(Guid id)
    {
        string data = await _service.DeleteCustomerContact(id);
        return data;
    }
}