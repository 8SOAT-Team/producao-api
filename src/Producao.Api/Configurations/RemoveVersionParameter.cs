using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Api.Configurations;
[ExcludeFromCodeCoverage]
public class RemoveVersionParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var versionParameter = operation.Parameters
            .FirstOrDefault(p => p.Name == "version");

        if (versionParameter != null) operation.Parameters.Remove(versionParameter);
    }
}