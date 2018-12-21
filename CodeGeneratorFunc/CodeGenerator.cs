using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CodeGeneratorFunc
{
    public static class CodeGenerator
    {
        [FunctionName("GetPersistenceClass")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Generating Persistence classes.");

            string entityName = req.Query["entityName"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            entityName = entityName ?? data?.entityName;

            var generator = new Generator() { EntityName = entityName};

            generator.GetPersistenceClass(Methods.GetPersistenceClass);

            return entityName != null
                ? (ActionResult)new OkObjectResult($"Hello, {entityName}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
        
    }
}
