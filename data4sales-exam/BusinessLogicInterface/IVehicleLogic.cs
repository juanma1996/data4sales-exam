using Domain;

namespace BusinessLogicInterface
{
    public interface IVehicleLogic : IEntityLogic<Vehicle>
    {
        Task Add(List<Vehicle> entity);
        Task<int> Add(Vehicle entity);
        Task Update(int id, Vehicle entity);
    }
}
