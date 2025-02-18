using CleanArch.UseCase;
using CleanArch.UseCase.Faults;
using CleanArch.UseCase.Options;
using Moq;
using Pedidos.Adapters.Controllers;

namespace Pedidos.Tests.UnitTests.Adapters.Controllers;
public class ControllerResultBuilderTests
{
    private readonly Mock<IUseCase> _useCaseMock;
    private readonly UseCaseError _useCaseError;

    public ControllerResultBuilderTests()
    {
        _useCaseMock = new Mock<IUseCase>();
        _useCaseError = new UseCaseError(UseCaseErrorType.BadRequest, "Bad Request Error");
    }

    [Fact]
    public void ForUseCase_ShouldInitializeBuilder()
    {
        // Arrange
        _useCaseMock.Setup(u => u.IsFailure).Returns(false);
        _useCaseMock.Setup(u => u.GetErrors()).Returns(new List<UseCaseError>());

        // Act
        var builder = ControllerResultBuilder<string, object>.ForUseCase(_useCaseMock.Object);

        // Assert
        Assert.NotNull(builder);
    }
       

    [Fact]
    public void Build_ShouldReturnFailureResult_WhenUseCaseFails()
    {
        // Arrange
        _useCaseMock.Setup(u => u.IsFailure).Returns(true);
        _useCaseMock.Setup(u => u.GetErrors()).Returns(new List<UseCaseError> { _useCaseError });
        var builder = ControllerResultBuilder<string, object>.ForUseCase(_useCaseMock.Object);

        // Act
        var result = builder.Build();

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Build_ShouldReturnSuccessResult_WhenUseCaseSucceeds()
    {
        // Arrange
        var useCaseResult = Any<object>.Some(new object());
        Func<object, string> adaptFunc = obj => obj.ToString();
        _useCaseMock.Setup(u => u.IsFailure).Returns(false);
        _useCaseMock.Setup(u => u.GetErrors()).Returns(new List<UseCaseError>());
        var builder = ControllerResultBuilder<string, object>.ForUseCase(_useCaseMock.Object)
            .WithResult(useCaseResult)
            .AdaptUsing(adaptFunc);

        // Act
        var result = builder.Build();

        // Assert
        Assert.True(result.IsSucceed);
    }
}