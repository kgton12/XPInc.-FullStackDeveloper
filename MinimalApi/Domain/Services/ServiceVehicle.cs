using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entity;
using MinimalApi.Domain.Interface;
using MinimalApi.Infrastructure.DB;

namespace MinimalApi.Domain.Services
{
    public class ServiceVehicle(DBContext context) : IServiceVehicle
    {
        private readonly DBContext _context = context;

        public async Task<List<Vehicle>> All(int page = 1, string name = "", string brand = "")
        {
            int itemsPerPage = 10;
            int skipCount = (page - 1) * itemsPerPage;

            IQueryable<Vehicle> query = _context.Vehicles;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(v => v.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(v => v.Brand.Contains(brand));
            }

            return await query.Skip(skipCount).Take(itemsPerPage).ToListAsync();
        }

        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task DeleteById(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<Vehicle?> FindById(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task Update(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
        }
        public ErrorsJson Validate(VehicleDTO vehicleDTO)
        {
            var errors = new ErrorsJson();

            if (string.IsNullOrEmpty(vehicleDTO.Name))
                errors.Message.Add("Name is required");

            if (string.IsNullOrEmpty(vehicleDTO.Brand))
                errors.Message.Add("Brand is required");

            if (vehicleDTO.Year == 0)
                errors.Message.Add("Year is required");

            return errors;
        }
    }
}
