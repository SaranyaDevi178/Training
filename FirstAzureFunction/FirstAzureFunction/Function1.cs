using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FirstAzureFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string sub1 = req.Query["sub1"];
            string sub2 = req.Query["sub2"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            sub1= sub1 ?? data?.sub1;
            sub2=sub2 ?? data?.sub2;
            int mark=Convert.ToInt32(sub1)+ Convert.ToInt32(sub2);

            string responseMessage = string.IsNullOrEmpty(name) & string.IsNullOrEmpty(sub1) & string.IsNullOrEmpty(sub2)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. your mark {mark}";

            return new OkObjectResult(responseMessage);
        }
    }
}
