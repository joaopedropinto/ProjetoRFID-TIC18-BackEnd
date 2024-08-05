namespace Cepedi.ProjetoRFID.Domain;

public interface IRfidTagRepository
{
    Task AddAsync(RfidTagEntity rfidTag);
    Task<RfidTagEntity> GetByRfidAsync(string rfid);
    Task<List<RfidTagEntity>> GetAllAsync();
    Task UpdateAsync(RfidTagEntity rfidTag);
    Task RemoveAsync(RfidTagEntity rfidTag);
}
