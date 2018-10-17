using Amazon.S3.Model;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json;
using Siliconvalve.Demo.S3Storage.src.Config;

namespace Siliconvalve.Demo.S3Storage.src
{
    public class S3TextFileExtensions : IExtensionConfigProvider
    {
        [JsonProperty("BucketName")]
        public string BucketName { get; set; }
        [JsonProperty("SecureKeyId")]
        public string SecureKeyId { get; set; }
        [JsonProperty("SecureKeyValue")]
        public string SecureKeyValue { get; set; }
        [JsonProperty("FileName")]
        public string FileName { get; set; }
        [JsonProperty("FileContents")]
        public string FileContents { get; set; }

        public void Initialize(ExtensionConfigContext context)
        {
            // Create binding rule for the attribute.
            var rule = context.AddBindingRule<S3TextFileAttribute>();
            rule.BindToCollector(BuildCollector);
        }

        private IAsyncCollector<PutObjectRequest> BuildCollector(S3TextFileAttribute attribute)
        {
            return new S3TextFileAsyncCollector(attribute.SecureKeyId, attribute.SecureKeyValue);
        }

        // All {} and %% in the Attribute have been resolved by now. 
        private PutObjectRequest BuildItemFromAttr(S3TextFileAttribute attribute)
        {
            return new PutObjectRequest
            {
                Key = attribute.FileName,
                BucketName = attribute.BucketName,
                ContentBody = attribute.FileContents
            };

        }
    }
}
