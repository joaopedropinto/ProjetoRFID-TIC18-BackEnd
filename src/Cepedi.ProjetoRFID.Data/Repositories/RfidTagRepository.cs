using Cepedi.ProjetoRFID.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.ProjetoRFID.Data;

public class RfidTagRepository : IRfidTagRepository
{
    private readonly ApplicationDbContext _context;

    public RfidTagRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RfidTagEntity> CreateRfidTagAsync(RfidTagEntity rfidTag)
    {
        await _context.RfidTag.AddAsync(rfidTag);
        await _context.SaveChangesAsync();
        return rfidTag;
    }

    public async Task<RfidTagEntity> ReturnRfidTagAsync(Guid id)
    {
        return await _context.RfidTag.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<RfidTagEntity>> ReturnAllRfidTagsAsync()
    {
        return await _context.Set<RfidTagEntity>().ToListAsync();
    }

    public async Task<RfidTagEntity> UpdateRfidTagAsync(RfidTagEntity rfidTag)
    {
        _context.RfidTag.Update(rfidTag);
        await _context.SaveChangesAsync();
        return rfidTag;
    }

    public async Task<RfidTagEntity> DeleteRfidTagAsync(Guid id)
    {
        var rfidTag = await ReturnRfidTagAsync(id);
        if (rfidTag == null)
        {
            return null;
        }

        _context.RfidTag.Remove(rfidTag);
        await _context.SaveChangesAsync();
        return rfidTag;
    }
}
