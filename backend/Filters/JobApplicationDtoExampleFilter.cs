using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace JobTrackerAPI.Filters
{
    public class JobApplicationDtoExampleFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.Name == "JobApplicationCreateDTO")
            {
                schema.Example = new OpenApiObject
                {
                    ["companyName"] = new OpenApiString("DNB"),
                    ["positionTitle"] = new OpenApiString("Backend Developer"),
                    ["jobUrl"] = new OpenApiString("https://www.finn.no/job/search?q=backend"),
                    ["status"] = new OpenApiString("Applied"),
                    ["appliedDate"] = new OpenApiString("2026-05-27T16:00:00"),
                    ["notes"] = new OpenApiString("Applied through FINN.no")
                };
            }
        }
    }
}