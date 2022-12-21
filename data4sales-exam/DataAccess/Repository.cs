using Dapper;
using DataAccessInterface;
using Domain;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IConfiguration configuration;
        public Repository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(T entity, string script)
        {
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                int newId = await connection.ExecuteAsync(script, entity);
                return newId;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var sql = $"DELETE FROM {GetTableName()} WHERE Id = @Id";
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {GetTableName()}";
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<T>(sql);
                return result.ToList();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var sql = $"SELECT * FROM {GetTableName()} WHERE Id = @Id";
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
                return result;
            }
        }

        public async Task UpdateAsync(T entity, string script)
        {
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(script, entity);
            }
        }

        public async Task InsertRelation(string script)
        {
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(script);
            }
        }

        private static string GetTableName()
        {
            return typeof(T) == typeof(People) ? "People" : typeof(T).Name + "s";
        }
    }
}
