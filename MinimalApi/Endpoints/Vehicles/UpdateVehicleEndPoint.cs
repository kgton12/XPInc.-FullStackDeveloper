using Microsoft.AspNetCore.Mvc;
using MinimalApi.Common;
using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Interface;

namespace MinimalApi.Endpoints.Vehicles
{
    public class UpdateVehicleEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync);
        }
        private static async Task<IResult> HandleAsync([FromRoute] int id, VehicleDTO vehicleDTO, IServiceVehicle serviceVehicle)
        {
            var validationResult = serviceVehicle.Validate(vehicleDTO);

            if (validationResult.Message.Count > 0)
            {
                return Results.BadRequest(validationResult);
            }

            var foundVehicle = await serviceVehicle.FindById(id);

            if (foundVehicle == null)
                return Results.NotFound();

            foundVehicle.Name = vehicleDTO.Name;
            foundVehicle.Brand = vehicleDTO.Brand;
            foundVehicle.Year = vehicleDTO.Year;

            await serviceVehicle.Update(foundVehicle);

            return Results.Ok(foundVehicle);

        }
    }
}
