using Microsoft.AspNetCore.Mvc;
using MinimalApi.Common;
using MinimalApi.Domain.Interface;

namespace MinimalApi.Endpoints.Vehicles
{
    public class GetVehicleEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync);
        }
        private static async Task<IResult> HandleAsync([FromQuery] int page, IServiceVehicle serviceVehicle)
        {
            var vehicles = await serviceVehicle.All(page);

            return Results.Ok(vehicles);
        }
    }
}
