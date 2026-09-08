using AutoTestsForApplications.DTO;
using AutoTestsForApplications.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTestsForApplications.Database;

public class OrderRepositoryDB : IOrderRepositoryDB
{
    private readonly IDbConnection _connection;

    public OrderRepositoryDB(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<ProductDB>> GetProductsByOrderIdAsync(int orderId)
    {
        const string sql = @"
            SELECT p.*
            FROM OrderItems oi
            JOIN Products p ON p.Id = oi.ProductId
            WHERE oi.OrderId = @OrderId";

        var result = await _connection.QueryAsync<ProductDB>(sql, new { OrderId = orderId });
        return result.ToList();
    }
}