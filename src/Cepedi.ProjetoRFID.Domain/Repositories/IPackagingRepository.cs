﻿using Cepedi.ProjetoRFID.Domain.Entities;

namespace Cepedi.ProjetoRFID.Domain.Repositories
{
    public interface IPackagingRepository
    {
        Task<PackagingEntity> CreatePackagingAsync(PackagingEntity entity);
        Task<List<PackagingEntity>> ReturnAllPackagesAsync();
        Task<List<PackagingEntity>> ReturnAllActivePackagesAsync();
        Task<PackagingEntity> ReturnPackagingByIdAsync(Guid id);
        Task<PackagingEntity> UpdatePackagingAsync(PackagingEntity entity);
        Task<PackagingEntity> DeletePackagingAsync(Guid id);
    }
}