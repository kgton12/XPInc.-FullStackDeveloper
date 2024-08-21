using Microsoft.AspNetCore.Mvc;
using MinimalApi.Common;
using MinimalApi.Domain.Interface;

namespace MinimalApi.Endpoints.Administrators
{
    public class GetAdministratorByIdEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandleAsync);
        }
        private static async Task<IResult> HandleAsync([FromRoute] int id, IServiceAdministrator serviceAdministrator)
        {
            var administrator = await serviceAdministrator.FindById(id);

            if (administrator == null)
                return Results.NotFound();

            return Results.Ok(administrator);
        }
    }
}
