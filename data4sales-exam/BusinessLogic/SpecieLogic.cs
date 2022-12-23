using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class SpecieLogic : EntityLogic<Specie>, ISpecieLogic
{
    public SpecieLogic(IRepository<Specie> specieRepository) : base(specieRepository)
    {
    }

    public async Task Add(IEnumerable<Specie> entity)
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

    public async Task<int> Add(Specie entity)
    {
        var script =
            @"INSERT INTO Species (AverageHeight, AverageLifespan, Designation, Classification, EyeColors, HairColors, Language, Name, SkinColors, Homeworld,url, created, edited, SwapiId)
                            VALUES (@AverageHeight, @AverageLifespan, @Designation, @Classification, @EyeColors, @HairColors, @Language, @Name, @SkinColors, @Homeworld, @url, @created, @edited, @SwapiId)";
        return await Repository.AddAsync(entity, script);
    }

    public async Task Update(int id, Specie entity)
    {
        entity.Id = id;
        entity.Edited = DateTime.Now;
        var script = @"UPDATE Species
                            SET AverageHeight = @AverageHeight,
                                AverageLifespan = @AverageLifespan,
                                Designation = @Designation,
                                Classification = @Classification,
                                EyeColors = @EyeColors,
                                Hair_Color = @HairColor,
                                Language = @Language,
                                Name = @Name,
                                SkinColors = @SkinColors,
                                Homeworld = @Homeworld,
                                url = @url,
                                created = @created,
                                edited = @edited
                            WHERE id = @id";
        await Repository.UpdateAsync(entity, script);
    }
}