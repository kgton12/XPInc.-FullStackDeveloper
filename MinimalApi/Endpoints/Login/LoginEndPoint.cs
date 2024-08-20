using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MinimalApi.Common;
using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entity;
using MinimalApi.Domain.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinimalApi.Endpoints.Login
{
    public class LoginEndPoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync);
        }

        private static async Task<IResult> HandleAsync([FromBody] LoginDTO loginDTO, IServiceAdministrator serviceAdministrator, IConfiguration configuration)
        {
            var adm = await serviceAdministrator.Login(loginDTO);

            if (adm is not null)
            {//TODO : Melhorar o retorno.
                string token = GenerateTokenJwt(adm, configuration);
                return Results.Ok(new
                {
                    Message = "Logged in successfully",
                    adm.Email,
                    adm.Profile,
                    Token = token
                });
            }
            else
            {
                return Results.BadRequest("Invalid login or password");
            }
        }
        private static string GenerateTokenJwt(Administrator administrator, IConfiguration configuration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? string.Empty));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new(ClaimTypes.Email, administrator.Email),
                    new("Perfil", administrator.Profile),
                };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
