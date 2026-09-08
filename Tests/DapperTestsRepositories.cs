using AutoTestsForApplications.Database;
using AutoTestsForApplications.DTO;
using AutoTestsForApplications.Interfaces;
using Dapper;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;


namespace AutoTestsForApplications.Tests;

public class DapperTestsRepositories
    {
    private SqliteConnection connection;
    private ICategoryRepositoryDB _categoryRepository;
    private IProductRepositoryDB _productRepository;
    private IOrderRepositoryDB _orderRepository;

    [OneTimeSetUp]
          public async Task Setup()
    {
        connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await DatabaseInitializer.InitializeAsync(connection);

        _categoryRepository = new CategoryRepositoryDB(connection);
        _productRepository = new ProductRepositoryDB(connection);
        _orderRepository = new OrderRepositoryDB(connection);
    }
    
    
    [OneTimeTearDown]
    public void TearDown()
    {
        connection.Dispose();
    }

   [Test]
    public async Task Test1_CategoriesCount()
    {
        var categories = await _categoryRepository.GetAllAsync();

        categories.Should().HaveCount(6);
    }

    [Test]
    public async Task Test2_GetProductById()
    {
        var product = await _productRepository.GetByIdAsync(1);

        product.Name.Should().Be("iPhone 15");
        product.Price.Should().Be(79990);
        product.Stock.Should().Be(15);
        product.CategoryId.Should().Be(1);
    }

    [Test]
    public async Task Test3_OrderItemsForUserOrder()
       {
       var products = await _orderRepository.GetProductsByOrderIdAsync(5);

        products.Should().HaveCount(4);
        products.Select(p => p.Id).Should().BeEquivalentTo(new[] { 2, 17, 15, 9 });
    }
}
