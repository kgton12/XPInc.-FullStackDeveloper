using Microsoft.IdentityModel.Tokens;
using MinimalApi.Domain.Entity;
using MinimalApi.Endpoints.Administrators;
using MinimalApi.Endpoints.Login;
using MinimalApi.Endpoints.Vehicles;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
                .MapEndpoint<CreateAdministratorEndPoint>()
                .MapEndpoint<GetAdministratorEndPoint>()
                .MapEndpoint<GetAdministratorByIdEndPoint>();

            endpoints
                .MapGroup("/vehicles")
                .WithTags("Vehicles")
                .RequireAuthorization()
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
