using Context;
using Dapper;
using DataAccessInterface;

namespace DataAccess;

public class ImporterRepository : IImporterRepository
{
    private readonly DapperContext context;

    public ImporterRepository(DapperContext context)
    {
        this.context = context;
    }

    public async Task CreateTable(string script)
    {
        using var connection = context.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(script);
    }
}