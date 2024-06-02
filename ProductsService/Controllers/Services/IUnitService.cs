using ProductsService.Common.Entities;
using ProductsService.Controllers.CustomModels;
using ProductsService.Controllers.Inputs;

namespace ProductsService.Controllers.Services
{
    public interface IUnitService
    {
        Task<string> DeleteCategory(Guid id);
        Task<string> DeleteUnit(Guid id);
        Task<List<CategoryModel>> GetAllCategories();
        Task<List<UnitModel>> GetAllUnit();
        Task<CategoryModel> GetCategoryById(Guid Id);
        Task<UnitModel> GetUnitById(Guid Id);
        Task<string> SaveCategory(CategoryInput input);
        Task<string> SaveUnit(UnitInput input);
        Task<string> UpdateCategory(CategoryUpdateInput input);
        Task<string> UpdateUnit(UnitUpdateInput input);
    }
}