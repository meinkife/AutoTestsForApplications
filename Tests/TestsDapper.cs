using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using AutoTestsForApplications.DTO;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace AutoTestsForApplications.Tests;

public class TestsDapper
    {
    private SqliteConnection connection;

    [OneTimeSetUp]
    public async Task Setup()
    {
        connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await DatabaseInitializer.InitializeAsync(connection);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        connection.Dispose();
    }

    [Test]
    public async Task Test1_CategoriesCount()
    {
        var categories = (await connection.QueryAsync<CategoryDB>(
            "SELECT * FROM Categories")).ToList();

        categories.Should().HaveCount(6);
    }

    [Test]
    public async Task Test2_GetProductById()
    {
        var product = await connection.QuerySingleAsync<ProductDB>(
            "SELECT * FROM Products WHERE Id = @Id",
            new { Id = 1 });

        product.Name.Should().Be("iPhone 15");
        product.Price.Should().Be(79990);
        product.Stock.Should().Be(15);
        product.CategoryId.Should().Be(1);
    }

    [Test]
    public async Task Test3_OrderItemsForUserOrder()
    {
        // Заказ 5 (юзер 5) содержит товары: ProductId 2, 17, 15, 9
        const string sql = @"
            SELECT p.*
            FROM OrderItems oi
            JOIN Products p ON p.Id = oi.ProductId
            WHERE oi.OrderId = @OrderId";

        var products = (await connection.QueryAsync<ProductDB>(
            sql, new { OrderId = 5 })).ToList();

        products.Should().HaveCount(4);
        products.Select(p => p.Id).Should().BeEquivalentTo(new[] { 2, 17, 15, 9 });
    }
}