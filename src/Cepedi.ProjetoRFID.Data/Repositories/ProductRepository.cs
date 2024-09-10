using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.ProjetoRFID.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ProductEntity> UpdateProductAsync(ProductEntity product)
    {
        _context.Product.Update(product);

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<ProductEntity> CreateProductAsync(ProductEntity product)
    {
        _context.Product.Add(product);

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<ProductEntity> ReturnProductAsync(Guid id)
    {
        return await
            _context.Product.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<ProductEntity>> ReturnAllProductsAsync()
    {
        return await _context.Set<ProductEntity>().ToListAsync();
    }

    public async Task<ProductEntity> DeleteProductAsync(Guid id)
    {
        var productEntity = await ReturnProductAsync(id);

        if (productEntity == null)
        {
            return null;
        }

        _context.Product.Remove(productEntity);

        await _context.SaveChangesAsync();

        return productEntity;
    }

    public async Task<List<ProductEntity>> GetProductsByRfidsAsync(List<string> rfids)
    {
        return await _context.Product
            .Where(p => rfids.Contains(p.RfidTag))
            .ToListAsync();
    }

    public async Task<ProductEntity> GetProductByRfidAsync(string rfid)
    {
        return await _context.Product
            .Where(p => p.RfidTag == rfid)
            .FirstOrDefaultAsync();
    }
}
