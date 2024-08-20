using Microsoft.AspNetCore.Mvc;
using MinimalApi.Common;
using MinimalApi.Domain.Interface;

namespace MinimalApi.Endpoints.Vehicles
{
    public class DeleteVehicleEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", HandleAsync);
        }
        private static async Task<IResult> HandleAsync([FromRoute] int id, IServiceVehicle serviceVehicle)
        {
            var foundVehicle = await serviceVehicle.FindById(id);

            if (foundVehicle == null)
                return Results.NotFound();

            await serviceVehicle.DeleteById(foundVehicle);

            return Results.NoContent();
        }
    }
}
