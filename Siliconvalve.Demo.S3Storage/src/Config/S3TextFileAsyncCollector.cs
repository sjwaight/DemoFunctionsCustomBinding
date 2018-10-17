using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Azure.WebJobs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Siliconvalve.Demo.S3Storage.src.Config
{
    public class S3TextFileAsyncCollector : IAsyncCollector<PutObjectRequest>
    {
        private readonly string secureKeyId;
        private readonly string secureKeyValue;

        private static IAmazonS3 client;

        public S3TextFileAsyncCollector(string keyId, string keyValue)
        {
            secureKeyValue = keyValue;
            secureKeyId = keyId;
            client = new AmazonS3Client(keyId, keyValue);
        }

        public async Task AddAsync(PutObjectRequest item, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UploadFile(item);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        private static async Task UploadFile(PutObjectRequest item)
        {
            try
            {
                var response = await client.PutObjectAsync(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
