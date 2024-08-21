using Microsoft.AspNetCore.Authorization;
using MinimalApi.Endpoints.Administrators;
using MinimalApi.Endpoints.Login;
using MinimalApi.Endpoints.Vehicles;

namespace MinimalApi.Common.Extensions
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints
                .MapGroup("/HealtCheck")
                .WithTags("Healt Check")
                .AllowAnonymous()
                .MapGet("/HealtCheck", () => new { message = "OK" });

            endpoints
                .MapGroup("/login")
                .WithTags("Login")
                .AllowAnonymous()
                .MapEndpoint<LoginEndPoint>();

            endpoints
                .MapGroup("/Admin")
                .WithTags("Admin")
                .RequireAuthorization()
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Adm" })
                .MapEndpoint<CreateAdministratorEndPoint>()
                .MapEndpoint<GetAdministratorEndPoint>()
                .MapEndpoint<GetAdministratorByIdEndPoint>();

            endpoints
                .MapGroup("/vehicles")
                .WithTags("Vehicles")
                .RequireAuthorization()
                .RequireAuthorization(new AuthorizeAttribute { Roles = "Adm, Editor" })
                .MapEndpoint<CreateVehicleEndPoint>()
                .MapEndpoint<GetVehicleEndPoint>()
                .MapEndpoint<GetVehicleByIdEndPoint>();

        }
        private static IEndpointRouteBuilder MapEndpoint<T>(this IEndpointRouteBuilder app) where T : IEndpoint
        {
            T.Map(app);
            return app;
        }
    }
}
