using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class StarshipLogic : EntityLogic<Starship>, IStarshipLogic
{
    public StarshipLogic(IRepository<Starship> starshipRepository) : base(starshipRepository)
    {
    }

    public async Task Add(IEnumerable<Starship> entity)
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

    public async Task<int> Add(Starship entity)
    {
        var script =
            @"INSERT INTO Starships (Mglt, HyperdriveRating, StarshipClass, Name, Model, Passengers, CargoCapacity, Consumables, CostInCredits, Crew, Length, Manufacturer, MaxAtmospheringSpeed,url, created, edited, SwapiId)
                            VALUES (@Mglt, @HyperdriveRating, @StarshipClass, @Name, @Model, @Passengers, @CargoCapacity, @Consumables, @CostInCredits, @Crew, @Length, @Manufacturer, @MaxAtmospheringSpeed, @url, @created, @edited, @SwapiId)";
        return await Repository.AddAsync(entity, script);
    }

    public async Task Update(int id, Starship entity)
    {
        entity.Id = id;
        entity.Edited = DateTime.Now;
        var script = @"UPDATE Starships
                            SET Mglt = @Mglt,
                                HyperdriveRating = @HyperdriveRating,
                                StarshipClass = @StarshipClass,
                                CargoCapacity = @CargoCapacity,
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