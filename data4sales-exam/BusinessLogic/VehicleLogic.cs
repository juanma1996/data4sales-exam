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
            var ids = item.Url.Split('/');
            if (ids.Length >= 5)
            {
                var exists = await Repository.Exists(int.Parse(ids[5]));
                if (!exists)
                {
                    item.SwapiId = int.Parse(ids[5]);
                    await Add(item);
                }
            }
        }
    }

    public async Task<int> Add(Vehicle entity)
    {
        var script =
            @"INSERT INTO Vehicles (Name, Model, Passengers, CargoCapacity, Consumables, CostInCredits, Crew, Length, Manufacturer, MaxAtmospheringSpeed,url, created, edited, SwapiId)
                            VALUES (@Name, @Model, @Passengers, @CargoCapacity, @Consumables, @CostInCredits, @Crew, @Length, @Manufacturer, @MaxAtmospheringSpeed, @url, @created, @edited, @SwapiId)";
        return await Repository.AddAsync(entity, script);
    }

    public async Task Update(int id, Vehicle entity)
    {
        entity.Id = id;
        entity.Edited = DateTime.Now;
        var script = @"UPDATE Vehicles
                            SET CargoCapacity = @CargoCapacity,
                                Consumables = @Consumables,
                                CostInCredits = @CostInCredits,
                                Crew = @Crew,
                                Length = @Length,
                                Manufacturer = @Manufacturer,
                                MaxAtmospheringSpeed = @MaxAtmospheringSpeed,
                                url = @url,
                                created = @created,
                                edited = @edited
                            WHERE id = @id";
        await Repository.UpdateAsync(entity, script);
    }
}