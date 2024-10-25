using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Blogify.Gateway.DocumentFilters;
public class UpstreamPathFilter : IDocumentFilter
{

    public UpstreamPathFilter()
    {
    }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        Console.WriteLine("UpstreamPathFilter is being applied.");
    }
}
