using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Api.Configurations;
[ExcludeFromCodeCoverage]
public class SetVersionInPath : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var updatedPaths = new OpenApiPaths();
        foreach (var path in swaggerDoc.Paths)
        {
            var newPath = path.Key.Replace("v{version}", swaggerDoc.Info.Version);
            updatedPaths.Add(newPath, path.Value);
        }

        swaggerDoc.Paths = updatedPaths;
    }
}