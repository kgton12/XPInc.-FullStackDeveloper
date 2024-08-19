using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entity;
using MinimalApi.Domain.Interface;
using MinimalApi.Infrastructure.DB;

namespace MinimalApi.Domain.Services
{
    public class ServiceAdministrator(DBContext context) : IServiceAdministrator
    {
        private readonly DBContext _context = context;

        public async Task<Administrator?> Login(LoginDTO loginDTO)
        {
            return await _context.Administrators.Where(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password).FirstOrDefaultAsync();
        }
    }
}
