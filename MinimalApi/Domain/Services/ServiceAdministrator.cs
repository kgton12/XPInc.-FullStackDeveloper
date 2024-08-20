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

        public async Task<Administrator> Create(Administrator administrator)
        {
            _context.Administrators.Add(administrator);
            await _context.SaveChangesAsync();
            return new Administrator
            {
                Id = administrator.Id,
                Email = administrator.Email,
                Profile = administrator.Profile
            };
        }

        public async Task<Administrator?> FindById(int id)
        {
            return await _context.Administrators
                .Where(a => a.Id == id)
                .Select(a => new Administrator
                {
                    Id = a.Id,
                    Email = a.Email,
                    Profile = a.Profile
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<Administrator>> GetAll(int page)
        {
            int itemsPerPage = 10;
            int skipCount = (page - 1) * itemsPerPage;

            IQueryable<Administrator> query = _context.Administrators
                .Select(a => new Administrator
                {
                    Id = a.Id,
                    Email = a.Email,
                    Profile = a.Profile
                });

            return await query.Skip(skipCount).Take(itemsPerPage).ToListAsync();
        }

        public async Task<Administrator?> Login(LoginDTO loginDTO)
        {
            return await _context.Administrators.Where(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password).FirstOrDefaultAsync();
        }

        public ErrorsJson Validate(AdministratorDTO administratorDTO)
        {
            var errors = new ErrorsJson();

            if (string.IsNullOrEmpty(administratorDTO.Email))
                errors.Message.Add("Email is required");

            if (string.IsNullOrEmpty(administratorDTO.Password))
                errors.Message.Add("Password is required");

            if (administratorDTO.Profile.ToString() == null)
                errors.Message.Add("Profile is required");

            return errors;
        }
    }
}
