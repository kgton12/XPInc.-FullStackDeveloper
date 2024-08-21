using Microsoft.AspNetCore.Mvc;
using MinimalApi.Common;
using MinimalApi.Domain.Interface;

namespace MinimalApi.Endpoints.Vehicles
{
    public class GetVehicleByIdEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandleAsync);
        }
        private static async Task<IResult> HandleAsync([FromRoute] int id, IServiceVehicle serviceVehicle)
        {
            var vehicle = await serviceVehicle.FindById(id);

            if (vehicle == null)
                return Results.NotFound();

            return Results.Ok(vehicle);
        }
    }
}
