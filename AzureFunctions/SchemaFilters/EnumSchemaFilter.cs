using BusinessLayer.Enums;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace AzureFunctions.SchemaFilters;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Enum.Any())
        {
            var schemaType = Assembly.GetAssembly(typeof(City)).GetTypes().Single(t => t.Name == context.Type.Name);
            schema.Enum = Enum.GetNames(schemaType)
                .Select(name => new OpenApiString(name))
                .Cast<IOpenApiAny>()
                .ToList();
            schema.Type = "string";
            schema.Default = schema.Enum.First();
            schema.Format = null;
        }
    }
}