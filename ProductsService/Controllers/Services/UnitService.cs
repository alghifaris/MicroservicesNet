using Microsoft.EntityFrameworkCore;
using ProductsService.Common.Entities;
using ProductsService.Controllers.CustomModels;
using ProductsService.Controllers.Inputs;

namespace ProductsService.Controllers.Services
{
    public class UnitService : IUnitService
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UnitModel>> GetAllUnit()
        {
            var data = await (from u in _dbContext.Units
                              join c in _dbContext.Categories on u.CategoryId equals c.Id
                              select new UnitModel
                              {
                                  Id = u.Id,
                                  Name = u.Name,
                                  Price = u.Price,
                                  CategoryId= c.Id,
                                  CategoryName = c.Name
                              }).ToListAsync();
            return data;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var data = await (from c in _dbContext.Categories
                              select new CategoryModel
                              {
                                  Id = c.Id,
                                  name = c.Name
                              }).ToListAsync();
            return data;
        }

        public async Task<UnitModel> GetUnitById(Guid Id)
        {
            var data = await (from u in _dbContext.Units
                              join c in _dbContext.Categories on u.CategoryId equals c.Id
                              where u.Id == Id
                              select new UnitModel
                              {
                                  Id = u.Id,
                                  Name = u.Name,
                                  Price = u.Price,
                                  CategoryId = c.Id,
                                  CategoryName = c.Name
                              }).FirstAsync();
            return data;
        }

        public async Task<CategoryModel> GetCategoryById(Guid Id)
        {
            var data = await (from c in _dbContext.Categories
                              where c.Id == Id
                              select new CategoryModel
                              {
                                  Id = c.Id,
                                  name = c.Name
                              }).FirstOrDefaultAsync();
            return data;
        }

        public async Task<string> SaveUnit(UnitInput input)
        {
            var result = "Unit has been created";
            var data = new Unit()
            {
                Name = input.Name,
                Price = input.Price,
                CategoryId = input.CategoryId
            };

            _dbContext.Units.Add(data);

            await _dbContext.SaveChangesAsync();
            return result;

        }
        public async Task<string> SaveCategory(CategoryInput input)
        {
            var result = "Category has been created";
            var data = new Category()
            {
                Name = input.Name
            };

            _dbContext.Categories.Add(data);
            await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<string> UpdateUnit(UnitUpdateInput input)
        {
            var result = "Unit has been Updated";
            var data = await _dbContext.Units.FirstOrDefaultAsync(w => w.Id == input.Id);

            if (data != null)
            {
                data.Name = input.Name;
                data.Price = input.Price;
                data.CategoryId = input.CategoryId;
                _dbContext.Units.Update(data);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                result = "Unit data notfound";
            }
          
            return result;
        }
        public async Task<string> UpdateCategory(CategoryUpdateInput input)
        {
            var result = "Categories has been updated";
            var data = await _dbContext.Categories.FirstOrDefaultAsync(w => w.Id == input.Id);

            if(data != null)
            {
                data.Name = input.Name;

                _dbContext.Categories.Update(data);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                result = "Category data not found";
            }
           

            return result;
        }

        public async Task<string> DeleteUnit(Guid id)
        {
            var result = "Unit has been deleted";
            var data = await _dbContext.Units.FirstOrDefaultAsync(w => w.Id == id);

            _dbContext.Units.Remove(data);
            await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<string> DeleteCategory(Guid id)
        {
            var result="Category has been deleted";
            var data = await _dbContext.Categories.FirstOrDefaultAsync(w => w.Id == id);

            if (!await _dbContext.Units.AnyAsync(w => w.CategoryId == id))
            {
                _dbContext.Categories.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                result = "Category is being used";
            }

     

            return result;
        }
    }
}
