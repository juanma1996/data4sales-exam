using ApiClientInterface;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class ImporterLogic : IImporterLogic
{
    private readonly IApiClient apiClient;
    private readonly IPlanetLogic planetLogic;
    private readonly IPeopleLogic peopleLogic;
    private readonly ISpecieLogic specieLogic;
    private readonly IFilmLogic filmLogic;
    private readonly IStarshipLogic starshipLogic;
    private readonly IVehicleLogic vehicleLogic;
    private readonly IImporterRepository repository;

    public ImporterLogic(IApiClient apiClient, IImporterRepository repository, IPlanetLogic planetLogic,
        IPeopleLogic peopleLogic, ISpecieLogic specieLogic, IFilmLogic filmLogic, IStarshipLogic starshipLogic,
        IVehicleLogic vehicleLogic)
    {
        this.apiClient = apiClient;
        this.repository = repository;
        this.planetLogic = planetLogic;
        this.peopleLogic = peopleLogic;
        this.specieLogic = specieLogic;
        this.filmLogic = filmLogic;
        this.starshipLogic = starshipLogic;
        this.vehicleLogic = vehicleLogic;
    }

    public async Task ImportAsync()
    {
        await CreateFilmTable();
        await CreatePlanetTable();
        await CreatePeopleTable();
        await CreateSpecieTable();
        await CreateStarshipTable();
        await CreateVehicleTable();
        await CreatePeopleFilmTable();
        await CreatePlanetFilmTable();
        await CreateSpecieFilmTable();
        await CreateStarshipFilmTable();
        await CreateVehicleFilmTable();
        await CreateSpeciePeopleTable();
        await CreateStarshipPeopleTable();
        await CreateVehiclePeopleTable();
        var films = await apiClient.GetAllFilmAsync();
        foreach (var item in films)
        {
            var people = apiClient.GetListAsync<People>(item.Characters);
            var planets = apiClient.GetListAsync<Planet>(item.Planets);
            var species = apiClient.GetListAsync<Specie>(item.Species);
            var starships = apiClient.GetListAsync<Starship>(item.Starships);
            var vehicles = apiClient.GetListAsync<Vehicle>(item.Vehicles);

            await Task.WhenAll(people, planets, species, starships, vehicles);

            await filmLogic.Add(item);
            await starshipLogic.Add(starships.Result);
            await vehicleLogic.Add(vehicles.Result);
            await planetLogic.Add(planets.Result);
            await peopleLogic.Add(people.Result);
            await specieLogic.Add(species.Result);
        }
    }

    private async Task CreateVehiclePeopleTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS VehiclePeople (
	                            VehicleId INTEGER,
                                PeopleId INTEGER,
                                PRIMARY KEY (VehicleId, PeopleId),
                                FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id),
                                FOREIGN KEY (PeopleId) REFERENCES People(Id)
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreateStarshipPeopleTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS StarshipPeople (
	                            StarshipId INTEGER,
                                PeopleId INTEGER,
                                PRIMARY KEY (StarshipId, PeopleId),
                                FOREIGN KEY (StarshipId) REFERENCES Starships(Id),
                                FOREIGN KEY (PeopleId) REFERENCES People(Id)
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreateSpeciePeopleTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS SpeciePeople (
	                            SpecieId INTEGER,
                                PeopleId INTEGER,
                                PRIMARY KEY (SpecieId, PeopleId),
                                FOREIGN KEY (SpecieId) REFERENCES Species(Id),
                                FOREIGN KEY (PeopleId) REFERENCES People(Id)
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreateVehicleFilmTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS VehicleFilms (
	                            VehicleId INTEGER,
                                FilmId INTEGER,
                                PRIMARY KEY (VehicleId, FilmId),
                                FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id),
                                FOREIGN KEY (FilmId) REFERENCES Films(Id)
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreateStarshipFilmTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS StarshipFilms (
	                            StarshipId INTEGER,
                                FilmId INTEGER,
                                PRIMARY KEY (StarshipId, FilmId),
                                FOREIGN KEY (StarshipId) REFERENCES Starships(Id),
                                FOREIGN KEY (FilmId) REFERENCES Films(Id)
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreateSpecieFilmTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS SpecieFilms (
	                            SpecieId INTEGER,
                                FilmId INTEGER,
                                PRIMARY KEY (SpecieId, FilmId),
                                FOREIGN KEY (SpecieId) REFERENCES Species(Id),
                                FOREIGN KEY (FilmId) REFERENCES Films(Id)
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreatePlanetFilmTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS PlanetFilms (
	                            PlanetId INTEGER,
                                FilmId INTEGER,
                                PRIMARY KEY (PlanetId, FilmId),
                                FOREIGN KEY (PlanetId) REFERENCES Planets(Id),
                                FOREIGN KEY (FilmId) REFERENCES Films(Id)
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreatePeopleFilmTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS PeopleFilms (
	                            PeopleId INTEGER,
                                FilmId INTEGER,
                                PRIMARY KEY (PeopleId, FilmId),
                                FOREIGN KEY (PeopleId) REFERENCES People(Id),
                                FOREIGN KEY (FilmId) REFERENCES Films(Id)
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreateFilmTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS Films (
	                            Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	                            Title VARCHAR(255) ,
	                            EpisodeId INT ,
	                            OpeningCrawl TEXT ,
	                            Director VARCHAR(255),
	                            Producer VARCHAR(255),
	                            ReleaseDate DATE,
	                            Url VARCHAR(255),
	                            Created DATE,
	                            Edited DATE,
                                SwapiId INT
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreatePlanetTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS Planets (
                                Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                                Name VARCHAR(255),
                                Diameter VARCHAR(255),
                                RotationPeriod VARCHAR(255),
                                OrbitalPeriod VARCHAR(255),
                                Gravity VARCHAR(255),
                                Population VARCHAR(255),
                                Climate VARCHAR(255),
                                Terrain VARCHAR(255),
                                SurfaceWater VARCHAR(255),
	                            Url VARCHAR(255) ,
	                            Created DATE ,
	                            Edited DATE ,
                                SwapiId INT
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreatePeopleTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS People (
	                            Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	                            Name VARCHAR(255) ,
	                            Birth_year VARCHAR(255),
	                            Eye_color VARCHAR(255),
	                            Gender VARCHAR(255),
	                            Hair_color VARCHAR(255),
	                            Height VARCHAR(255),
	                            Mass VARCHAR(255),
	                            Skin_color VARCHAR(255),
	                            Homeworld VARCHAR(255),
	                            Url VARCHAR(255) ,
	                            Created DATE ,
	                            Edited DATE ,
                                SwapiId INT
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreateSpecieTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS Species (
                                Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                                Name VARCHAR(255),
                                Classification VARCHAR(255),
                                Designation VARCHAR(255),
                                AverageHeight VARCHAR(255),
                                SkinColors VARCHAR(255),
                                HairColors VARCHAR(255),
                                EyeColors VARCHAR(255),
                                AverageLifespan VARCHAR(255),
                                Homeworld VARCHAR(255),
                                Language VARCHAR(255),
	                            Url VARCHAR(255) ,
	                            Created DATE ,
	                            Edited DATE ,
                                SwapiId INT
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreateStarshipTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS Starships (
                                Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                                Name VARCHAR(255),
                                Model VARCHAR(255),
                                Manufacturer VARCHAR(255),
                                CostInCredits VARCHAR(255),
                                Length VARCHAR(255),
                                MaxAtmospheringSpeed VARCHAR(255),
                                Crew VARCHAR(255),
                                Passengers VARCHAR(255),
                                CargoCapacity VARCHAR(255),
                                Consumables VARCHAR(255),
                                HyperdriveRating VARCHAR(255),
                                Mglt VARCHAR(255),
                                StarshipClass VARCHAR(255),
	                            Url VARCHAR(255) ,
	                            Created DATE ,
	                            Edited DATE ,
                                SwapiId INT
                            );";
        await repository.CreateTable(script);
    }

    private async Task CreateVehicleTable()
    {
        const string script = @"CREATE TABLE IF NOT EXISTS Vehicles (
                                Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                                Name VARCHAR(255),
                                Model VARCHAR(255),
                                Manufacturer VARCHAR(255),
                                CostInCredits VARCHAR(255),
                                Length VARCHAR(255),
                                MaxAtmospheringSpeed VARCHAR(255),
                                Crew VARCHAR(255),
                                Passengers VARCHAR(255),
                                CargoCapacity VARCHAR(255),
                                Consumables VARCHAR(255),
	                            Url VARCHAR(255) ,
	                            Created DATE ,
	                            Edited DATE ,
                                SwapiId INT
                            );";
        await repository.CreateTable(script);
    }
}