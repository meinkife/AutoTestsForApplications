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
        return result.ToList(); }

         public async Task<List<string>> GetCitiesByCategoryAsync(string categoryName)
    {
        const string sql = @"
            SELECT DISTINCT a.City
            FROM Categories c
            JOIN Products p ON p.CategoryId = c.Id
            JOIN OrderItems oi ON oi.ProductId = p.Id
            JOIN Orders o ON o.Id = oi.OrderId
            JOIN Addresses a ON a.UserId = o.UserId
            WHERE c.Name = @CategoryName";

        var result = await _connection.QueryAsync<string>(sql, new { CategoryName = categoryName });
        return result.ToList();
    }
    public async Task<List<int>> GetUsersWhoBoughtBothCategoriesAsync(string category1, string category2)
    {
        const string sql = @"
        SELECT o.UserId
        FROM Orders o
        JOIN OrderItems oi ON oi.OrderId = o.Id
        JOIN Products p ON p.Id = oi.ProductId
        JOIN Categories c ON c.Id = p.CategoryId
        WHERE c.Name = @Category1

        INTERSECT

        SELECT o.UserId
        FROM Orders o
        JOIN OrderItems oi ON oi.OrderId = o.Id
        JOIN Products p ON p.Id = oi.ProductId
        JOIN Categories c ON c.Id = p.CategoryId
        WHERE c.Name = @Category2";

        var result = await _connection.QueryAsync<int>(sql,
            new { Category1 = category1, Category2 = category2 });
        return result.ToList();
    }
}
