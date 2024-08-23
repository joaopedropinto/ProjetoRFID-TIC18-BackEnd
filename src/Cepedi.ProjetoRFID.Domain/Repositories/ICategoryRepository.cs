using Cepedi.ProjetoRFID.Domain.Entities;
namespace Cepedi.ProjetoRFID.Domain.Repositories;

public interface ICategoryRepository
{
    Task<CategoryEntity> CreateCategoryAsync(CategoryEntity category);
    Task<CategoryEntity> ReturnCategoryAsync(Guid id);
    Task<List<CategoryEntity>> ReturnAllCategoriesAsync();
    Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category);
    Task<ProductEntity> ReturnProductCategoryAsync(Guid id);
    Task<CategoryEntity> DeleteCategoryAsync(Guid id);
}