using Dapper;
using DataAccessInterface;
using Domain;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DataAccess;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly string connectionString;

    public Repository(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        this.connectionString = configuration.GetConnectionString("DefaultConnection") ??
                                throw new ArgumentNullException("Missing DefaultConnection value");
    }

    public async Task<int> AddAsync(T entity, string script)
    {
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        var newId = await connection.ExecuteAsync(script, entity);
        return newId;
    }

    public async Task DeleteAsync(int id)
    {
        var sql = $"DELETE FROM {GetTableName()} WHERE Id = @Id";
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        var sql = $"SELECT * FROM {GetTableName()}";
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        var result = await connection.QueryAsync<T>(sql);
        return result.ToList();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var sql = $"SELECT * FROM {GetTableName()} WHERE Id = @Id";
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        var result = await connection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
        return result;
    }

    public async Task UpdateAsync(T entity, string script)
    {
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        await connection.ExecuteAsync(script, entity);
    }

    public async Task InsertRelation(string script)
    {
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        await connection.ExecuteAsync(script);
    }

    private static string GetTableName()
    {
        return typeof(T) == typeof(People) ? "People" : typeof(T).Name + "s";
    }
}