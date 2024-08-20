using Microsoft.AspNetCore.Mvc;
using MinimalApi.Common;
using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Interface;

namespace MinimalApi.Endpoints.Login
{
    public class LoginEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync);
        }

        private static async Task<IResult> HandleAsync([FromBody] LoginDTO loginDTO, IServiceAdministrator serviceAdministrator)
        {
            if (await serviceAdministrator.Login(loginDTO) is not null)
            {
                return Results.Ok("Login efetuado com sucesso");
            }
            else
            {
                return Results.BadRequest("Login ou senha inválidos");
            }
        }
    }
}
