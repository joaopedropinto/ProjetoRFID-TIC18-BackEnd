using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.ProjetoRFID.Data.Repositories
{
    public class PackagingRepositiory : IPackagingRepository
    {
        private readonly ApplicationDbContext _context;

        public PackagingRepositiory(ApplicationDbContext context) 
            => _context = context;

        public async Task<PackagingEntity> CreatePackagingAsync(PackagingEntity packaging)
        {
            _context.Packaging.Add(packaging);

            await _context.SaveChangesAsync();

            return packaging;
        }

        public async Task<PackagingEntity> DeletePackagingAsync(Guid id)
        {
            var packaging = await ReturnPackagingByIdAsync(id);

            if(packaging is not null)
            {
                packaging.Delete();

                _context.Update(packaging);

                await _context.SaveChangesAsync();
            }

            return packaging;
        }

        public async Task<List<PackagingEntity>> ReturnAllPackagesAsync()
            => await _context.Set<PackagingEntity>().ToListAsync();

        public async Task<List<PackagingEntity>> ReturnAllActivePackagesAsync()
            => await _context.Set<PackagingEntity>().Where(p => !p.IsDeleted).ToListAsync();

        public async Task<PackagingEntity> ReturnPackagingByIdAsync(Guid id) 
            => await _context.Packaging.Where(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<PackagingEntity> ReturnActivePackagingByIdAsync(Guid id)
            => await _context.Packaging.Where(p => p.Id == id && !p.IsDeleted).FirstOrDefaultAsync();

        public async Task<PackagingEntity> UpdatePackagingAsync(PackagingEntity packaging)
        {
            _context.Update(packaging);

            await _context.SaveChangesAsync();

            return packaging;
        }
    }
}
