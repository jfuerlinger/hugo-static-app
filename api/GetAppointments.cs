using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JFuerlinger.Portfolio.Model;

namespace JFuerlinger.Portfolio
{
    public static class GetAppointments
    {
        [FunctionName("GetAppointments")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // string name = req.Query["name"];

            // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;

            // string responseMessage = string.IsNullOrEmpty(name)
            //     ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //     : $"Hello, {name}. This HTTP triggered function executed successfully.";

            var result = new Appointment[] {
                new Appointment()
                {
                    DisplayName = "Saunieren in Tischberg",
                    From = new DateTime(2020, 10, 29, 14, 00, 00),
                    To = new DateTime(2020, 10, 30, 10, 00, 00)
                },
                new Appointment()
                {
                    DisplayName = "Lea abholen",
                    From = new DateTime(2020, 10, 30, 11, 00, 00),
                    To = new DateTime(2020, 10, 30, 13, 00, 00)
                }
            };

            return await Task.FromResult(new OkObjectResult(result));
        }
    }
}
