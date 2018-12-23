using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;

namespace CodeGeneratorFunc
{
    public static class GetCodeHTTPResponse
    {
        [FunctionName("GetCodeHTTPResponse")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Generating Persistence classes.");

            string entityName = req.Query["entityName"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            entityName = entityName ?? data?.entityName;

            var generator = new Generator() { EntityName = entityName };

            var codeList = generator.GetCodes(Methods.GetPersistLayerClasses);

            var json = JsonConvert.SerializeObject(codeList);


            return codeList != null
                ? new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, "application/json") }
                : new HttpResponseMessage(HttpStatusCode.InternalServerError) {
                    Content = new StringContent("Please pass a name on the query string or in the request body", Encoding.UTF8, "application/json")};

        }
    }
}
