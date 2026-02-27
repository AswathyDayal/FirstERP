using FirstERP.Domain.Entities;
using FirstERP.Domain.Interfaces;
using FirstERP.Infrastructure.Data;
using Microsoft.Data.SqlClient;

namespace FirstERP.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public ProductRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = new List<Product>();

        await using var connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync(cancellationToken);

        const string sql = """
                           SELECT Id, Name, Price, StockQuantity, CreatedAtUtc
                           FROM dbo.Products
                           ORDER BY Name ASC;
                           """;

        await using var command = new SqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            products.Add(new Product
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                StockQuantity = reader.GetInt32(3),
                CreatedAtUtc = reader.GetDateTime(4)
            });
        }

        return products;
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await using var connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync(cancellationToken);

        const string sql = """
                           INSERT INTO dbo.Products (Name, Price, StockQuantity, CreatedAtUtc)
                           VALUES (@Name, @Price, @StockQuantity, @CreatedAtUtc);
                           """;

        await using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Name", product.Name);
        command.Parameters.AddWithValue("@Price", product.Price);
        command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
        command.Parameters.AddWithValue("@CreatedAtUtc", product.CreatedAtUtc);

        await command.ExecuteNonQueryAsync(cancellationToken);
    }
}
