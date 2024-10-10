namespace Cepedi.ProjetoRFID.Domain.Services
{
	public interface IMinioService
	{
		Task<string> EnsureBucketExistsAsync(string name);
		Task<string> UploadImageAsync(string imageBase64);
	}
}
