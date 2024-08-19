using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entity;

namespace MinimalApi.Domain.Interface
{
    public interface IServiceAdministrator
    {
        Task<Administrator?> Login(LoginDTO loginDTO);
    }
}
