using Amazon.S3.Model;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Siliconvalve.Demo.S3Storage.src;
using System;

namespace SiliconValve.Demo.TestFunctionApp
{
    public static class TestFunction01
    {
        [FunctionName("TestFunction01")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, [S3TextFile(BucketName = "demo", RegionName = "us-west-1")] out PutObjectRequest outputFile, ILogger log)
        {
            outputFile = new PutObjectRequest
            {
                Key = $"TestFile-{DateTimeOffset.UtcNow.Ticks}.txt",
                ContentBody = "Random body text"
            };
        }
    }
}
