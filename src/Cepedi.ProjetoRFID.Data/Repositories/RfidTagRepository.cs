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

    public async Task AddAsync(RfidTagEntity rfidTag)
    {
        await _context.RfidTag.AddAsync(rfidTag);
        await _context.SaveChangesAsync();
    }

    public async Task<RfidTagEntity> GetByRfidAsync(string rfid)
    {
        return await _context.RfidTag.FirstOrDefaultAsync(e => e.Rfid == rfid);
    }

    public async Task<List<RfidTagEntity>> GetAllAsync()
    {
        return await _context.RfidTag.ToListAsync();
    }

    public async Task UpdateAsync(RfidTagEntity rfidTag)
    {
        _context.RfidTag.Update(rfidTag);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(RfidTagEntity rfidTag)
    {
        _context.RfidTag.Remove(rfidTag);
        await _context.SaveChangesAsync();
    }
}
