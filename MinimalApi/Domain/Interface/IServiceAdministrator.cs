using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entity;

namespace MinimalApi.Domain.Interface
{
    public interface IServiceAdministrator
    {
        Task<Administrator?> Login(LoginDTO loginDTO);
        Task<Administrator> Create(Administrator administrator);
        Task<List<Administrator>> GetAll(int page);
        Task<Administrator?> FindById(int page);
        ErrorsJson Validate(AdministratorDTO administratorDTO);
    }
}
