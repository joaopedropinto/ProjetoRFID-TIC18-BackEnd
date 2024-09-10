using Cepedi.ProjetoRFID.Domain.Entities;
namespace Cepedi.ProjetoRFID.Domain.Repositories;

public interface IReadoutRepository
{
    Task<ReadoutEntity> CreateReadoutAsync(ReadoutEntity readout);
    Task<ReadoutEntity> ReturnReadoutAsync(Guid id);
    Task<List<ReadoutEntity>> ReturnAllReadoutsAsync();
}
