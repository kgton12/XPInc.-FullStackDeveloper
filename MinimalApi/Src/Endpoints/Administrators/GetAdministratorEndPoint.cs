using Microsoft.AspNetCore.Mvc;
using MinimalApi.Common;
using MinimalApi.Domain.Interface;

namespace MinimalApi.Endpoints.Administrators
{
    public class GetAdministratorEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync);
        }
        private static async Task<IResult> HandleAsync([FromQuery] int page, IServiceAdministrator serviceAdministrator)
        {
            return Results.Ok(await serviceAdministrator.GetAll(page));
        }
    }
}
