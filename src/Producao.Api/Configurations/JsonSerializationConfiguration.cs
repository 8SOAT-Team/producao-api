using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pedidos.Api.Configurations;

public static class JsonSerializationConfiguration
{
    public static IServiceCollection ConfigureJsonSerialization(this IServiceCollection services)
    {
        var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            MaxDepth = 16,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        jsonOptions.Converters.Add(new JsonStringEnumConverter());

        services.AddSingleton(jsonOptions);

        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.ReferenceHandler = jsonOptions.ReferenceHandler;
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.SerializerOptions.MaxDepth = jsonOptions.MaxDepth;
        });

        return services;
    }
}