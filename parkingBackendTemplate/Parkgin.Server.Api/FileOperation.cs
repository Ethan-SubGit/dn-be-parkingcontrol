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
            //if (operation.OperationId.ToLower() == "apifileuploadpost")
            //{
            //    operation.Parameters.Clear();//Clearing parameters
            //    operation.Parameters.Add(new NonBodyParameter
            //    {
            //        Name = "File",
            //        In = "formData",
            //        Description = "Upload Image",
            //        Required = true,
            //        Type = "file"
            //    });
            //    operation.Consumes.Add("application/form-data");
            //}
            //if (operation.OperationId == "Post")
            //{
            //    operation.Parameters = new List<IParameter>
            //    {
            //        new NonBodyParameter
            //        {
            //            Name = "myFile",
            //            Required = true,
            //            Type = "file",
            //            In = "formData"
            //        }
            //    };
            //}
        }
    }
}
