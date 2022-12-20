﻿using ApiClientInterface;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class ImporterLogic : IImporterLogic
    {

        private readonly IApiClient apiClient;
        private readonly IImporterRepository repository;

        public ImporterLogic(IApiClient apiClient, IImporterRepository repository)
        {
            this.apiClient = apiClient;
            this.repository = repository;
        }

        public async Task Import()
        {
            CreateFilmTable();
            CreatePlanetTable();
            CreatePeopleTable();
            CreateSpecieTable();
            CreateStarshipTable();
            CreateVehicleTable();
            var films = await apiClient.GetAllFilmAsync();
            foreach (var item in films)
            {
                var people = apiClient.GetListAsync<People>(item.characters);
                var planets = apiClient.GetListAsync<Planet>(item.planets);
                var species = apiClient.GetListAsync<Specie>(item.species);
                var starships = apiClient.GetListAsync<Starship>(item.starships);
                var vehicles = apiClient.GetListAsync<Vehicle>(item.vehicles);

                await Task.WhenAll(people, planets, species, starships, vehicles);

            }
        }

        private void CreateFilmTable()
        {
            string script = @"CREATE TABLE IF NOT EXISTS Films (
	                            Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	                            Title VARCHAR(255) NOT NULL,
	                            Episode_id INT NOT NULL,
	                            Opening_crawl TEXT NOT NULL,
	                            Director VARCHAR(255) NOT NULL,
	                            Producer VARCHAR(255) NOT NULL,
	                            Release_date DATE NOT NULL,
	                            Url VARCHAR(255) NOT NULL,
	                            Created DATE NOT NULL,
	                            Edited DATE NOT NULL
                            );";
            repository.CreateTable(script);
        }

        private void CreatePlanetTable()
        {
            string script = @"CREATE TABLE IF NOT EXISTS Planets (
                                Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                                Name VARCHAR(255),
                                Diameter INTEGER,
                                RotationPeriod INTEGER,
                                OrbitalPeriod INTEGER,
                                Gravity VARCHAR(255),
                                Population VARCHAR(255),
                                Climate VARCHAR(255),
                                Terrain VARCHAR(255),
                                SurfaceWater INTEGER,
	                            Url VARCHAR(255) NOT NULL,
	                            Created DATE NOT NULL,
	                            Edited DATE NOT NULL,
                            );";
            repository.CreateTable(script);
        }

        private void CreatePeopleTable()
        {
            string script = @"CREATE TABLE IF NOT EXISTS People (
	                            Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	                            Name VARCHAR(255) NOT NULL,
	                            Birth_year VARCHAR(255),
	                            Eye_color VARCHAR(255),
	                            Gender VARCHAR(255),
	                            Hair_color VARCHAR(255),
	                            Height VARCHAR(255),
	                            Mass VARCHAR(255),
	                            Skin_color VARCHAR(255),
	                            HomeworldId int,
	                            Url VARCHAR(255) NOT NULL,
	                            Created DATE NOT NULL,
	                            Edited DATE NOT NULL,
	                            FOREIGN KEY (HomeworldId) REFERENCES Planet(Id)
                            );";
            repository.CreateTable(script);
        }

        private void CreateSpecieTable()
        {
            string script = @"CREATE TABLE IF NOT EXISTS Species (
                Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                Name VARCHAR(255),
                Classification VARCHAR(255),
                Designation VARCHAR(255),
                AverageHeight VARCHAR(255),
                SkinColors VARCHAR(255),
                HairColors VARCHAR(255),
                EyeColors VARCHAR(255),
                AverageLifespan VARCHAR(255),
                HomeworldId int,
                Language VARCHAR(255),
	            Url VARCHAR(255) NOT NULL,
	            Created DATE NOT NULL,
	            Edited DATE NOT NULL,
	            FOREIGN KEY (HomeworldId) REFERENCES Planet(Id)
            );";                
            repository.CreateTable(script);
        }

        private void CreateStarshipTable()
        {
            string script = @"CREATE TABLE IF NOT EXISTS Starships (
                                Id INTEGER PRIMARY KEY,
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
	                            Url VARCHAR(255) NOT NULL,
	                            Created DATE NOT NULL,
	                            Edited DATE NOT NULL,
                            );";
            repository.CreateTable(script);
        }

        private void CreateVehicleTable()
        {
            string script = @"CREATE TABLE IF NOT EXISTS Vehicles (
                                Id INTEGER PRIMARY KEY,
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
	                            Url VARCHAR(255) NOT NULL,
	                            Created DATE NOT NULL,
	                            Edited DATE NOT NULL,
                            );";                   
            repository.CreateTable(script);
        }
    }
}
