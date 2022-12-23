using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class PeopleLogic : EntityLogic<People>, IPeopleLogic
{
    public PeopleLogic(IRepository<People> peopleRepository) : base(peopleRepository)
    {
    }

    public async Task Add(IEnumerable<People> entity)
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

    public async Task<int> Add(People entity)
    {

        var script =
            @"INSERT INTO People (Birth_Year, Eye_Color, Gender, Hair_Color, Height, Mass, Name, Skin_Color, Homeworld,url, created, edited, SwapiId)
                            VALUES (@BirthYear, @EyeColor, @Gender, @HairColor, @Height, @Mass, @Name, @SkinColor, @Homeworld, @url, @created, @edited, @SwapiId)";
        return await Repository.AddAsync(entity, script);
    }

    public async Task Update(int id, People entity)
    {
        entity.Id = id;
        entity.Edited = DateTime.Now;
        var script = @"UPDATE People
                            SET Birth_Year = @BirthYear,
                                Eye_Color = @EyeColor,
                                Gender = @Gender,
                                Hair_Color = @HairColor,
                                Height = @Height,
                                Mass = @Mass,
                                Name = @Name,
                                Skin_Color = @Skin_Color,
                                Homeworld = @Homeworld,
                                url = @url,
                                created = @created,
                                edited = @edited
                            WHERE id = @id";
        await Repository.UpdateAsync(entity, script);
    }
}