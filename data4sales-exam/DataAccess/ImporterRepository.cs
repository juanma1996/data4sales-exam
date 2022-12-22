using DataAccessInterface;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace DataAccess
{
    public class ImporterRepository : IImporterRepository
    {
        private readonly IConfiguration configuration;
        public ImporterRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task CreateTable(string script)
        {
            await using var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            await connection.ExecuteAsync(script);
        }
    }
}
