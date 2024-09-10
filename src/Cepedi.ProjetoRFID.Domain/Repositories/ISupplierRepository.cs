using Cepedi.ProjetoRFID.Domain.Entities;
namespace Cepedi.ProjetoRFID.Domain.Repositories;

public interface ISupplierRepository
{
    Task<SupplierEntity> CreateSupplierAsync(SupplierEntity Name);
    Task<SupplierEntity> ReturnSupplierAsync(Guid id);
    Task<List<SupplierEntity>> ReturnAllSuppliersAsync();
    Task<SupplierEntity> UpdateSupplierAsync(SupplierEntity Name);
    Task<ProductEntity> ReturnProductSupplierAsync(Guid id);
    Task<SupplierEntity> DeleteSupplierAsync(Guid id);
}