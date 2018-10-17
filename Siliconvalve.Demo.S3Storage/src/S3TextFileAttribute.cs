using Microsoft.Azure.WebJobs.Description;
using System;

namespace Siliconvalve.Demo.S3Storage.src
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class S3TextFileAttribute : Attribute
    {
        [AutoResolve]
        public string BucketName { get; set; }

        [AutoResolve]
        public string RegionName { get; set; }

        [AutoResolve]
        public string FileName { get; set; }

        [AppSetting]
        public string SecureKeyId { get; set; }

        [AppSetting]
        public string SecureKeyValue { get; set; }

        [AutoResolve]
        public string FileContents { get; set; }
    }
}
