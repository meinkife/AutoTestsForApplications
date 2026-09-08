using AutoTestsForApplications.DTO;
using AutoTestsForApplications.Interfaces;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace AutoTestsForApplications.Database;

public class ProductRepositoryDB : IProductRepositoryDB
{
    private readonly IDbConnection _connection;

    public ProductRepositoryDB(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<ProductDB> GetByIdAsync(int id)
    {
        return await _connection.QuerySingleAsync<ProductDB>(
            "SELECT * FROM Products WHERE Id = @Id",
            new { Id = id });
    }
}