using Dapper;
using DataAccessInterface;
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

        public Task<int> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var sql = "SELECT * FROM " + typeof(T).Name;
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<T>(sql);
                return result.ToList();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM People WHERE Id = @Id";
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
