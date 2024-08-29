using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.ProjetoRFID.Data.Repositories;

public class ReadoutRepository : IReadoutRepository
{
    private readonly ApplicationDbContext _context;

    public ReadoutRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<ReadoutEntity> CreateReadoutAsync(ReadoutEntity readout)
    {
        _context.Readout.Add(readout);

        await _context.SaveChangesAsync();

        return readout;
    }

    public async Task<ReadoutEntity> ReturnReadoutAsync(Guid id)
    {
        return await
            _context.Readout.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<ReadoutEntity>> ReturnAllReadoutsAsync()
    {
        return await _context.Set<ReadoutEntity>().ToListAsync();
    }
}
