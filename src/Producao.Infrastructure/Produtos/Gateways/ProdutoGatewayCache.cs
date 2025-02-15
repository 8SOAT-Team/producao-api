using Pedidos.Adapters.Gateways.Caches;
using Pedidos.Apps.Produtos.Enums;
using Pedidos.Apps.Produtos.Gateways.Produtos;
using Pedidos.Domain.Produtos.Entities;

namespace Pedidos.Infrastructure.Produtos.Gateways;

public record ProdutoKey(Guid? Id = null, ProdutoCategoria? Categoria = null);

public class ProdutoGatewayCache(IProdutoGateway nextExecution, ICacheContext cache)
    : CacheGateway<ProdutoKey>(cache), IProdutoGateway
{
    private readonly ICacheContext _cache = cache;

    protected override Dictionary<string, Func<ProdutoKey, (string cacheKey, bool InvalidateCacheOnChanges)>>
        CacheKeys => new()
    {
        [nameof(GetProdutoByIdAsync)] =
            p => ($"{nameof(ProdutoGatewayCache)}:{nameof(GetProdutoByIdAsync)}:{p.Id}", false),
        [nameof(GetProdutoCompletoByIdAsync)] = p =>
            ($"{nameof(ProdutoGatewayCache)}:{nameof(GetProdutoCompletoByIdAsync)}:{p.Id}", false),
        [nameof(ListarProdutosByIdAsync)] = p =>
            ($"{nameof(ProdutoGatewayCache)}:{nameof(ListarProdutosByIdAsync)}:{p.Id}", false),
    };
    public async Task<Produto?> GetProdutoByIdAsync(Guid id)
    {
        var prodKey = new ProdutoKey(id);
        var getKey = CacheKeys[nameof(GetProdutoByIdAsync)];
        var (cacheKey, _) = getKey(prodKey);

        var result = await _cache.GetItemByKeyAsync<Produto>(cacheKey);

        if (result.HasValue) return result.Value;

        var item = await nextExecution.GetProdutoByIdAsync(id);
        _ = await _cache.SetNotNullStringByKeyAsync(cacheKey, item);

        return item;
    }

    public async Task<Produto?> GetProdutoCompletoByIdAsync(Guid id)
    {
        var prodKey = new ProdutoKey(id);
        var getKey = CacheKeys[nameof(GetProdutoCompletoByIdAsync)];
        var (cacheKey, _) = getKey(prodKey);

        var result = await _cache.GetItemByKeyAsync<Produto>(cacheKey);

        if (result.HasValue) return result.Value;

        var item = await nextExecution.GetProdutoByIdAsync(id);
        _ = await _cache.SetNotNullStringByKeyAsync(cacheKey, item);

        return item;
    }

    public Task<ICollection<Produto>> ListarProdutosByIdAsync(ICollection<Guid> ids)
    {
        return nextExecution.ListarProdutosByIdAsync(ids);
    }
}