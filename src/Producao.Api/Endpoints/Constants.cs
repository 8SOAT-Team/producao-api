using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Api.Endpoints;

[ExcludeFromCodeCoverage]
public class Constants
{
    public const string IdempotencyHeaderKey = "x-requestid";
    public const string ApiName = "FastOrder Producao API";
}
