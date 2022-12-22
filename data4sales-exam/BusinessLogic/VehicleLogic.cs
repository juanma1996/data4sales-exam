using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class VehicleLogic : EntityLogic<Vehicle>, IVehicleLogic
{
    public VehicleLogic(IRepository<Vehicle> vehicleRepository) : base(vehicleRepository)
    {
    }

    public Task Add(IEnumerable<Vehicle> entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> Add(Vehicle entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Vehicle entity)
    {
        throw new NotImplementedException();
    }
}