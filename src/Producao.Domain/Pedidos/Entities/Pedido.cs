using System.Text.Json.Serialization;
using Pedidos.Domain.Entities;
using Pedidos.Domain.Exceptions;
using Pedidos.Domain.Pedidos.DomainEvents;
using Pedidos.Domain.Pedidos.Enums;

namespace Pedidos.Domain.Pedidos.Entities;

public class Pedido : Entity, IAggregateRoot
{
    private const StatusPedido StatusInicial = StatusPedido.EmPreparacao;
    private const StatusPedido StatusFinal = StatusPedido.Pronto;

    protected Pedido()
    {
    }

    [JsonConstructor]
    public Pedido(Guid id, List<ItemDoPedido> itensDoPedido)
    {
        ValidationDomain(id, itensDoPedido);

        Id = id;
        ItensDoPedido = itensDoPedido;
        DataPedido = DateTime.Now;
        StatusPedido = StatusInicial;
    }

    public DateTime DataPedido { get; private set; }
    public StatusPedido StatusPedido { get; private set; }
    public virtual ICollection<ItemDoPedido> ItensDoPedido { get; set; }

    private static void ValidationDomain(Guid id, List<ItemDoPedido> itens)
    {
        DomainExceptionValidation.When(id == Guid.Empty, "Id inválido");
        DomainExceptionValidation.When(itens.Count <= 0, "O pedido deve conter pelo menos um item");
    }

    public Pedido FinalizarPreparo()
    {
        DomainExceptionValidation.When(StatusPedido != StatusPedido.EmPreparacao,
            $"Status do pedido não permite finalizar o preparo. O status deve ser {StatusPedido.EmPreparacao} para finalizar o preparo.");

        StatusPedido = StatusFinal;
        RaiseEvent(new PedidoFinalizado(Id));
        return this;
    }
}