using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class PlanetLogic : EntityLogic<Planet>, IPlanetLogic
    {
        //private readonly IRepository<Planet> planetRepository;
        //private readonly IRepository<People> peopleRepository;
        //private readonly IApiClient apiClient;

        public PlanetLogic(IRepository<Planet> planetRepository) : base(planetRepository)/*, IRepository<People> peopleRepository, IApiClient apiClient*/
        {
            //this.planetRepository = planetRepository;
            //this.peopleRepository = peopleRepository;
            //this.apiClient = apiClient;
        }

        public async Task Add(List<Planet> planets)
        {
            foreach (var item in planets)
            {
                var newPlanetId = await Add(item);
                //var people = await apiClient.GetListAsync<People>(item.residents);
                //foreach (var resident in people)
                //{
                //    var script = @"INSERT INTO People (birth_year, eye_color, gender, hair_color, height, mass, name, skin_color)
                //                    OUTPUT INSERTED.[Id]
                //                    VALUES (@birth_year, @eye_color, @gender, @hair_color, @height, @mass, @name, @skin_color)";

                //    var newResidentId = await peopleRepository.AddAsync(resident, script);

                //    var relationScript = @"INSERT INTO PlanetPeople (birth_year, eye_color, gender, hair_color, height, mass, name, skin_color)
                //                    OUTPUT INSERTED.[Id]
                //                    VALUES (@birth_year, @eye_color, @gender, @hair_color, @height, @mass, @name, @skin_color)";
                //}
            }
        }

        public async Task<int> Add(Planet planet)
        {
            var script = @"INSERT INTO Planets (climate, diameter, gravity, name, orbitalperiod, population, rotationperiod, surfacewater, terrain, url, created, edited)
                            VALUES (@climate, @diameter, @gravity, @name, @orbitalperiod, @population, @rotationperiod, @surfacewater, @terrain, @url, @created, @edited)";
            return await Repository.AddAsync(planet, script);
        }

        public async Task Update(int id, Planet planet)
        {
            planet.Id = id;
            planet.Edited = DateTime.Now;
            var script = @"UPDATE Planets
                            SET climate = @climate,
                                diameter = @diameter,
                                gravity = @gravity,
                                name = @name,
                                orbital_period = @orbital_period,
                                population = @population,
                                rotation_period = @rotation_period,
                                surface_water = @surface_water,
                                terrain = @terrain,
                                url = @url,
                                created = @created,
                                edited = @edited
                            WHERE id = @id";
            await Repository.UpdateAsync(planet, script);
        }
    }
}
