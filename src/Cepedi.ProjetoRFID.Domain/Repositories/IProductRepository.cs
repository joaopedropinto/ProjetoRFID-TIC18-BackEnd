using Cepedi.ProjetoRFID.Domain.Entities;
namespace Cepedi.ProjetoRFID.Domain.Repositories;

public interface IProductRepository
{
    Task<ProductEntity> CreateProductAsync(ProductEntity product);
    Task<ProductEntity> ReturnProductAsync(int id);
    Task<List<ProductEntity>> ReturnAllProductsAsync();
    Task<ProductEntity> UpdateProductAsync(ProductEntity product);
    Task<ProductEntity> DeleteProductAsync(int id);
    Task<List<ProductEntity>> GetProductsByRfidsAsync(List<string> rfids);
}
