using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Adapters.Controllers.Pedidos;
using Pedidos.Adapters.Controllers.Pedidos.Dtos;
using Pedidos.Adapters.Types.Results;
using Pedidos.Api.Dtos;
using Pedidos.Api.Endpoints;
using Pedidos.Api.Endpoints.Extensions;

namespace Pedidos.Api.Producao;

[ExcludeFromCodeCoverage]
public static class ProducaoEndpoint
{
    public static void AddEndpointProducao(this RouteGroupBuilder group)
    {
        const string producaoTag = "Produção";

        group.MapPost("/pedido", async ([FromHeader(Name = Constants.IdempotencyHeaderKey)] Guid? idempotencyKey,
                [FromServices] IPedidoController pedidoController,
                [FromBody] NovoPedidoDto request) =>
            {
                var pedidoCriado = await pedidoController.CreatePedidoAsync(request);

                IResult result = null!;

                pedidoCriado.Match(
                    p => result = Results.Created($"/pedido/{p.Id}", p),
                    errors => result = pedidoCriado.GetFailureResult());

                return result;
            }).WithTags(producaoTag)
            .Produces<PedidoDto>((int)HttpStatusCode.Created)
            .Produces<AppBadRequestProblemDetails>((int)HttpStatusCode.BadRequest)
            .Produces((int)HttpStatusCode.NotFound)
            .WithSummary("Inicie a produção informando os itens.")
            .WithOpenApi();

        group.MapGet("/pedido/{id:guid}",
                async ([FromHeader(Name = Constants.IdempotencyHeaderKey)] Guid? idempotencyKey,
                    [FromServices] IPedidoController pedidoController, [FromRoute] Guid id) =>
                {
                    var pedido = await pedidoController.GetPedidoByIdAsync(id);
                    return pedido.GetResult();
                }).WithTags(producaoTag)
            .Produces<PedidoDto>((int)HttpStatusCode.Created)
            .Produces<AppBadRequestProblemDetails>((int)HttpStatusCode.BadRequest)
            .Produces((int)HttpStatusCode.NotFound)
            .WithSummary("Obtenha um pedido")
            .WithOpenApi();

        group.MapGet("/pedido/status", async ([FromHeader(Name = Constants.IdempotencyHeaderKey)] Guid? idempotencyKey,
                [FromServices] IPedidoController pedidoController) =>
            {
                var pedidos = await pedidoController.GetAllPedidosPending();
                return pedidos.GetResult();
            }).WithTags(producaoTag)
            .Produces<List<PedidoDto>>((int)HttpStatusCode.Created)
            .Produces<AppBadRequestProblemDetails>((int)HttpStatusCode.BadRequest)
            .Produces((int)HttpStatusCode.NotFound)
            .WithSummary("Lista de pedidos Pendentes (Em Preparação)")
            .WithOpenApi();

        group.MapPut("/pedido/{id:guid}/preparo", async (
                [FromHeader(Name = Constants.IdempotencyHeaderKey)]
                Guid? idempotencyKey,
                [FromServices] IPedidoController pedidoController,
                [FromRoute] Guid id) =>
            {
                var result = await pedidoController.FinalizarPreparoPedido(id);
                return result.GetResult();
            }).WithTags(producaoTag)
            .Produces<PedidoDto>((int)HttpStatusCode.Created)
            .Produces<AppBadRequestProblemDetails>((int)HttpStatusCode.BadRequest)
            .Produces((int)HttpStatusCode.NotFound)
            .WithSummary("Finaliza o preparo do pedido")
            .WithOpenApi();
    }
}