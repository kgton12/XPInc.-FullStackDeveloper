using Microsoft.AspNetCore.Mvc;
using MinimalApi.Common;
using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entity;
using MinimalApi.Domain.Interface;

namespace MinimalApi.Endpoints.Administrators
{
    public class CreateAdministratorEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync);
        }
        private static async Task<IResult> HandleAsync([FromBody] AdministratorDTO administratorDTO, IServiceAdministrator serviceAdministrator)
        {
            var validationResult = serviceAdministrator.Validate(administratorDTO);

            if (validationResult.Message.Count > 0)
            {
                return Results.BadRequest(validationResult);
            }

            var result = await serviceAdministrator.Create(new Administrator
            {
                Email = administratorDTO.Email,
                Password = administratorDTO.Password,
                Profile = administratorDTO.Profile.ToString(),
            });

            return Results.Created(string.Empty, result);
        }
    }
}
