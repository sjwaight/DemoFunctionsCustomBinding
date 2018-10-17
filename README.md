# DemoFunctionsCustomBinding
Shows how you can build your own custom binding for Azure Functions.

This is a simple demonstration of how you could build an output binding for Azure Functions to write text files to Amazon's S3 storage platform.

You need a configuration file (or runtime configuration loaded in) that looks similar to this:

```javascript
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "AzureWebJobsDashboard": "UseDevelopmentStorage=true",
    "SecureKeyId": "YOUR_AWS_KEY_ID",
    "SecureKeyValue":  "YOUR_AWS_KEY_VALUE",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  }
}
```
Note that your runtime can be whatever you wish (and that is supported by the v2 Functions runtime).

If you want to know more, check out the [official documentation](https://github.com/Azure/azure-webjobs-sdk/wiki/Creating-custom-input-and-output-bindings) on building your own Bindings.
