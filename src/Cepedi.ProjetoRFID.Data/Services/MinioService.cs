using System.Text.RegularExpressions;
using Cepedi.ProjetoRFID.Domain.Services;
using Minio;
using Minio.DataModel.Args;

namespace Cepedi.ProjetoRFID.Data.Services
{
	public class MinioService : IMinioService
	{
		private readonly IMinioClient _minioclient;

		public MinioService(IMinioClient minioclient)
		{
			_minioclient = minioclient;
		}

		public async Task<string> EnsureBucketExistsAsync(string bucketName)
		{
			var bucketExists = await _minioclient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));

			if(!bucketExists)
				await _minioclient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));

			return bucketName;
		}

		public async Task<string> UploadImageAsync(string imageBase64)
		{
			var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(imageBase64, "");
			var imageBytes = Convert.FromBase64String(data);

			var objectName = "";

			using(var stream = new MemoryStream(imageBytes))
			{
				var bucketName = await EnsureBucketExistsAsync("rfid-product-images");

				objectName = $"{Guid.NewGuid()}";

				var args = new PutObjectArgs()
							.WithBucket(bucketName)
							.WithObject(objectName)
							.WithStreamData(stream)
							.WithObjectSize(imageBytes.Length)
							.WithContentType("image/jpeg");

				await _minioclient.PutObjectAsync(args);

			}

			return objectName;
		}

		public async Task<string?> GetObjectUrlAsync(string bucketName, string objectName)
		{
			var args = new PresignedGetObjectArgs()
				.WithBucket(bucketName)
				.WithObject(objectName)
				.WithExpiry(604800);

			var url = await _minioclient.PresignedGetObjectAsync(args);

			return url;
		}
	}
}
