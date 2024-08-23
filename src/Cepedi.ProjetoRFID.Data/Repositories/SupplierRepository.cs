using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.ProjetoRFID.Data.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly ApplicationDbContext _context;

    public SupplierRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<SupplierEntity> UpdateSupplierAsync(SupplierEntity name)
    {
        _context.Supplier.Update(name);

        await _context.SaveChangesAsync();

        return name;
    }

    public async Task<SupplierEntity> CreateSupplierAsync(SupplierEntity name)
    {
        _context.Supplier.Add(name);

        await _context.SaveChangesAsync();

        return name;
    }

    public async Task<SupplierEntity> ReturnSupplierAsync(Guid id)
    {
        return await
            _context.Supplier.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<SupplierEntity>> ReturnAllSuppliersAsync()
    {
        return await _context.Set<SupplierEntity>().ToListAsync();
    }

    public async Task<ProductEntity> ReturnProductSupplierAsync(Guid id)
    {
        return await
            _context.Product.Where(e => e.Id == id).FirstOrDefaultAsync();
    }
    public async Task<SupplierEntity> DeleteSupplierAsync(Guid id)
    {
        var supplierEntity = await ReturnSupplierAsync(id);

        if (supplierEntity == null)
        {
            return null;
        }

        _context.Supplier.Remove(supplierEntity);

        await _context.SaveChangesAsync();

        return supplierEntity;
    }
}
