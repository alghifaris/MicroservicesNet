using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsService;
using ProductsService.Common.Entities;
using ProductsService.Controllers.CustomModels;
using ProductsService.Controllers.Inputs;
using ProductsService.Controllers.Services;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{    
    private readonly IUnitService _service;

    public ProductsController(IUnitService service)
    {        
        _service = service;
    }

    [Route("GetAllUnits")]
    [HttpPost]
    public async Task<ActionResult<List<UnitModel>>> GetAllUnits(
         )
    {
        return await _service.GetAllUnit();
    }

    [Route("GetAllCategories")]
    [HttpPost]
    public async Task<ActionResult<List<CategoryModel>>> GetAllCategories(
        )
    {
        return await _service.GetAllCategories();
    }

    [Route("GetUnitById")]
    [HttpPost]
    public async Task<ActionResult<UnitModel>> GetUnitById(Guid id
       )
    {
        return await _service.GetUnitById(id);
    }

    [Route("GetCategoryById")]
    [HttpPost]
    public async Task<ActionResult<CategoryModel>> GetCategoryById(Guid id)
    {
        return await _service.GetCategoryById(id);
    }

    [Route("CreateUnit")]
    [HttpPost]
    public async Task<ActionResult<string>> CreateUnit(UnitInput input)
    {
        string data = await _service.SaveUnit(input);
        return CreatedAtAction(nameof(GetAllUnits), new { message = data }, input);
    }
    [Route("CreateCategory")]
    [HttpPost]
    public async Task<ActionResult<string>> CreateCategory(CategoryInput input)
    {
        string data = await _service.SaveCategory(input);
        return CreatedAtAction(nameof(GetAllCategories), new { message = data }, input);
    }
    [Route("UpdateUnit")]
    [HttpPost]
    public async Task<ActionResult<string>> UpdateCustomer(UnitUpdateInput input)
    {
        string data = await _service.UpdateUnit(input);
        return data;
    }
    [Route("UpdateCategory")]
    [HttpPost]
    public async Task<ActionResult<string>> UpdateCategory(CategoryUpdateInput input)
    {
        string data = await _service.UpdateCategory(input);
        return data;
    }
    [Route("DeleteUnit")]
    [HttpPost]
    public async Task<ActionResult<string>> DeleteCustomer(Guid id)
    {
        string data = await _service.DeleteUnit(id);
        return data;
    }
    [Route("DeleteCategory")]
    [HttpPost]
    public async Task<ActionResult<string>> DeleteCategory(Guid id)
    {
        string data = await _service.DeleteCategory(id);
        return data;
    }
}
