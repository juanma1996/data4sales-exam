using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class VehicleLogic : EntityLogic<Vehicle>, IVehicleLogic
{
    public VehicleLogic(IRepository<Vehicle> vehicleRepository) : base(vehicleRepository)
    {
    }

    public async Task Add(IEnumerable<Vehicle> entity)
    {
        foreach (var item in entity)
        {
            await Add(item);
        }
    }

    public async Task<int> Add(Vehicle entity)
    {
        throw new NotImplementedException();
    }

    public async Task Update(int id, Vehicle entity)
    {
        throw new NotImplementedException();
    }
}