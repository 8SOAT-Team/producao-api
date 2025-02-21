using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Infrastructure.DependencyInjection;
[ExcludeFromCodeCoverage]
public static class DecoratorExtension
{
    public static IServiceCollection DecorateIf<TService, TDecorator>(this IServiceCollection services,
        Func<bool> condition)
        where TService : class
        where TDecorator : TService
    {
        return !condition() ? services : services.Decorate<TService, TDecorator>();
    }
}