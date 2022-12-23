using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class FilmLogic : EntityLogic<Film>, IFilmLogic
{
    public FilmLogic(IRepository<Film> filmRepository) : base(filmRepository)
    {
    }

    public async Task Add(IEnumerable<Film> entity)
    {
        foreach (var item in entity)
        {
            await Add(item);
        }
    }

    public async Task<int> Add(Film entity)
    {
        entity.SwapiId = entity.EpisodeId;
        var exists = await Repository.Exists(entity.SwapiId);
        if (!exists)
        {
            var script =
                @"INSERT INTO Films (Director, OpeningCrawl, Producer, ReleaseDate, Title, url, created, edited, EpisodeId, SwapiId)
                            VALUES (@Director, @OpeningCrawl, @Producer, @ReleaseDate, @Title, @url, @created, @edited, @EpisodeId, @SwapiId)";
            return await Repository.AddAsync(entity, script);
        }

        return default;
    }

    public async Task Update(int id, Film entity)
    {
        entity.Id = id;
        entity.Edited = DateTime.Now;
        var script = @"UPDATE Films
                            SET Director = @Director,
                                EpisodeId = @EpisodeId,
                                OpeningCrawl = @OpeningCrawl,
                                Producer = @Producer,
                                ReleaseDate = @ReleaseDate,
                                Title = @Title,
                                url = @url,
                                created = @created,
                                edited = @edited
                            WHERE id = @id";
        await Repository.UpdateAsync(entity, script);
    }
}