using Microsoft.AspNetCore.Mvc;
using MinimalApi.Common;
using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entity;
using MinimalApi.Domain.Interface;

namespace MinimalApi.Endpoints.Vehicles
{
    public class CreateVehicleEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync);
        }
        private static async Task<IResult> HandleAsync([FromBody] VehicleDTO vehicleDTO, IServiceVehicle serviceVehicle)
        {
            var validationResult = serviceVehicle.Validate(vehicleDTO);

            if (validationResult.Message.Count > 0)
            {
                return Results.BadRequest(validationResult);
            }

            var result = await serviceVehicle.Create(new Vehicle
            {
                Name = vehicleDTO.Name,
                Brand = vehicleDTO.Brand,
                Year = vehicleDTO.Year,
            });

            return Results.Created(string.Empty, result);
        }
    }
}
