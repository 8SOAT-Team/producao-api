using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Domain.Exceptions;
[ExcludeFromCodeCoverage]
public class InvalidEmailArgumentException : InvalidArgumentException
{
    private const string ErrorMessage = "Email não está em um formato válido.";

    public InvalidEmailArgumentException() : base(ErrorMessage)
    {
    }
}