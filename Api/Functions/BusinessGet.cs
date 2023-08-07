using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Context;

namespace Api.Functions
{

    public class BusinessesGet
    {
        [FunctionName("BusinessesGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Businesses")] HttpRequest req)
        {
            try
            {
                var context = new BusinessContext();
                var studentsWithSameName = context.Businesses;
                //.Where(s => s.FirstName == GetName())
                //.ToList();

                Console.WriteLine(studentsWithSameName.FirstOrDefault().Name);

                return new OkObjectResult(studentsWithSameName);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                Console.WriteLine(s);
            }

            return new OkObjectResult("Dang");
        }
    }
}
