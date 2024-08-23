namespace Cepedi.ProjetoRFID.Domain;

public interface IRfidTagRepository
{
    Task<RfidTagEntity> CreateRfidTagAsync(RfidTagEntity rfidTag);
    Task<RfidTagEntity> ReturnRfidTagAsync(Guid id);
    Task<List<RfidTagEntity>> ReturnAllRfidTagsAsync();
    Task<RfidTagEntity> UpdateRfidTagAsync(RfidTagEntity rfidTag);
    Task<RfidTagEntity> DeleteRfidTagAsync(Guid id);
}
