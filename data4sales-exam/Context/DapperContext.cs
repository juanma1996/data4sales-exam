using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Context;

public class DapperContext
{
    private readonly string connectionString;

    public DapperContext(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        this.connectionString = configuration.GetConnectionString("DefaultConnection") ??
                                throw new ArgumentNullException("Missing DefaultConnection value");
    }

    public IDbConnection CreateConnection()
        => new MySqlConnection(connectionString);
}