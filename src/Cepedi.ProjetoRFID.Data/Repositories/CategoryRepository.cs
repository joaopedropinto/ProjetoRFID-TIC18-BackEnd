using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.ProjetoRFID.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity name)
    {
        _context.Category.Update(name);

        await _context.SaveChangesAsync();

        return name;
    }

    public async Task<CategoryEntity> CreateCategoryAsync(CategoryEntity name)
    {
        _context.Category.Add(name);

        await _context.SaveChangesAsync();

        return name;
    }

    public async Task<CategoryEntity> ReturnCategoryAsync(int id)
    {
        return await
            _context.Category.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<CategoryEntity>> ReturnAllCategoriesAsync()
    {
        return await _context.Set<CategoryEntity>().ToListAsync();
    }

    public async Task<ProductEntity> ReturnProductCategoryAsync(int id)
    {
        return await
            _context.Product.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<CategoryEntity> DeleteCategoryAsync(int id)
    {
        var categoryEntity = await ReturnCategoryAsync(id);

        if (categoryEntity == null)
        {
            return null;
        }

        _context.Category.Remove(categoryEntity);

        await _context.SaveChangesAsync();

        return categoryEntity;
    }
}
