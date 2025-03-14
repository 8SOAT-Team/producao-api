﻿using System.Runtime.Serialization;

namespace Pedidos.Apps.Produtos.Enums;

public enum ProdutoCategoria
{
    [EnumMember(Value = nameof(Lanche))] Lanche,
    [EnumMember(Value = nameof(Acompanhamento))] Acompanhamento,
    [EnumMember(Value = nameof(Bebida))] Bebida,
    [EnumMember(Value = nameof(Sobremesa))] Sobremesa
}