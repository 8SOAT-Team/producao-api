﻿using Pedidos.Adapters.Types.Results;
using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Api.Endpoints.Extensions;
[ExcludeFromCodeCoverage]
public static class ResultExtension
{
    public static IResult GetResult<T>(this Result<T> result)
    {
        if (result.IsFailure) return result.GetFailureResult();

        return result.HasValue ? Results.Ok(result.Value) : Results.NotFound();
    }

    public static IResult GetFailureResult<T>(this Result<T> result)
    {
        var badRequestDetails = result.ProblemDetails.FirstOrDefault(x => x is AppBadRequestProblemDetails);
        return badRequestDetails is null ? Results.Problem() : Results.BadRequest(badRequestDetails);
    }
}