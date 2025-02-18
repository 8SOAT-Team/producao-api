using Moq;
using Pedidos.Adapters.Gateways.Caches;
using Pedidos.Adapters.Types.Results;

namespace Pedidos.Tests.UnitTests.Adapters.Gateways.Cache;
public class CacheGatewayTests
{
    private readonly Mock<ICacheContext> _mockCacheContext;

    public CacheGatewayTests()
    {
        _mockCacheContext = new Mock<ICacheContext>();
    }

    [Fact]
    public async Task InvalidateCacheOnChange_ShouldInvalidateCache_WhenInvalidateCacheOnChangesIsTrue()
    {
        // Arrange
        var entity = new TestEntity();
        var cacheGateway = new TestCacheGateway(_mockCacheContext.Object);

        _mockCacheContext
            .Setup(c => c.InvalidateCacheAsync(It.IsAny<string>()))
            .ReturnsAsync(Result<string>.Succeed("Success"));

        // Act
        await cacheGateway.InvalidateCacheOnChange(entity);

        // Assert
        _mockCacheContext.Verify(c => c.InvalidateCacheAsync(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task InvalidateCacheOnChange_ShouldNotInvalidateCache_WhenInvalidateCacheOnChangesIsFalse()
    {
        // Arrange
        var entity = new TestEntity();
        var cacheGateway = new TestCacheGateway(_mockCacheContext.Object, false);

        // Act
        await cacheGateway.InvalidateCacheOnChange(entity);

        // Assert
        _mockCacheContext.Verify(c => c.InvalidateCacheAsync(It.IsAny<string>()), Times.Never);
    }

    private class TestEntity { }

    private class TestCacheGateway : CacheGateway<TestEntity>
    {
        private readonly bool _invalidateCacheOnChanges;

        public TestCacheGateway(ICacheContext cache, bool invalidateCacheOnChanges = true) : base(cache)
        {
            _invalidateCacheOnChanges = invalidateCacheOnChanges;
        }

        protected override Dictionary<string, Func<TestEntity, (string cacheKey, bool InvalidateCacheOnChanges)>> CacheKeys =>
            new()
            {
                { "TestKey", entity => ("TestCacheKey", _invalidateCacheOnChanges) }
            };

        public new async Task InvalidateCacheOnChange(TestEntity target)
        {
            await base.InvalidateCacheOnChange(target);
        }
    }
}