using MinimalApi.Domain.Entity;

namespace MinimalApi.Domain.Interface
{
    public interface IServiceVehicle
    {
        Task<List<Vehicle>> All(int page = 1, string name = "", string brand = "");
        Task<Vehicle?> FindById(int id);
        Task Create(Vehicle vehicle);
        Task Update(Vehicle vehicle);
        Task DeleteById(Vehicle vehicle);
    }
}
