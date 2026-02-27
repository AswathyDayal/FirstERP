using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FirstERP.Infrastructure.Data;

public class SqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("FirstErpDb")
            ?? throw new InvalidOperationException("Connection string 'FirstErpDb' is not configured.");
    }

    public SqlConnection CreateConnection() => new(_connectionString);
}
