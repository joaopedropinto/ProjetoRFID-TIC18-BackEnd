using Refit;

namespace Cepedi.ProjetoRFID.Domain.Services;
public interface IService
{
    [Post("api/v1/Send")]
    Task<ApiResponse<HttpResponseMessage>> SendNotification([Body] object notification);
}