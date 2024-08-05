using Cepedi.ProjetoRFID.Data;
using Cepedi.ProjetoRFID.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public class RfidService
{
    private readonly ApplicationDbContext _context;

    public RfidService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task ProcessRfidJsonAsync(string filePath)
    {
        var jsonData = await File.ReadAllTextAsync(filePath);
        var rfidTags = JsonSerializer.Deserialize<List<RfidTagEntity>>(jsonData);

        if (rfidTags == null)
        {
            throw new Exception("Invalid JSON data");
        }
        foreach (var tag in rfidTags)
        {
            var rfid = tag.Rfid;
            var data = await _context.RfidTag.Where(e => e.Rfid == rfid).ToListAsync();
        }
    }
}
