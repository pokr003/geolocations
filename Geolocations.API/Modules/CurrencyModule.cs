using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Geolocations.API.Modules;

public sealed class CurrencyModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/currencies", () => "Get All Currencies");
        app.MapGet("/currencies/{id:guid}", ([FromRoute] Guid id) => $"Get currency by id: {id}");
    }
}