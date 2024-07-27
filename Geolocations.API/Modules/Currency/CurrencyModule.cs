using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Geolocations.API.Modules.Currency;

public sealed class CurrencyModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/currencies", GetAllCurrencies);
        app.MapGet("/currencies/{id:guid}", GetCurrencyById);
    }

    private CurrencyQuery GetAllCurrencies(CurrencyQuery query)
    {
        return query;
    }

    private object GetCurrencyById([FromRoute] Guid id, [FromQuery] string? fields)
    {
        return new
        {
            id,
            fields
        };
    }
}


