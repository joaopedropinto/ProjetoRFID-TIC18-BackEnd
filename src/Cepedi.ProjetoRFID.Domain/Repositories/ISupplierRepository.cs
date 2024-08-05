using Cepedi.ProjetoRFID.Domain.Entities;
namespace Cepedi.ProjetoRFID.Domain.Repositories;

public interface ISupplierRepository
{
    Task<SupplierEntity> CreateSupplierAsync(SupplierEntity Name);
    Task<SupplierEntity> ReturnSupplierAsync(int id);
    Task<List<SupplierEntity>> ReturnAllSuppliersAsync();
    Task<SupplierEntity> UpdateSupplierAsync(SupplierEntity Name);
    Task<ProductEntity> ReturnProductCategoryAsync(int id);
    Task<SupplierEntity> DeleteSupplierAsync(int id);
}