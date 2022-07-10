using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkgin.Server.Api
{
    public class FileOperation : IOperationFilter
    {
        

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
           
        }
    }
}
