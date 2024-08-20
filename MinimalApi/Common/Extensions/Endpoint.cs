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
                .MapGet("/HealtCheck", () => new { message = "OK" });

            endpoints
                .MapGroup("/login")
                .WithTags("Login")
                .MapEndpoint<LoginEndPoint>();

            endpoints
                .MapGroup("/vehicles")
                .WithTags("Vehicles")
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
