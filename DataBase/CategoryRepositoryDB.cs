using AutoTestsForApplications.DTO;
using AutoTestsForApplications.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

    namespace AutoTestsForApplications.Database
{ 

    public class CategoryRepositoryDB : ICategoryRepositoryDB
{
    private readonly IDbConnection _connection;

    public CategoryRepositoryDB(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<CategoryDB>> GetAllAsync()
    {
        var result = await _connection.QueryAsync<CategoryDB>("SELECT * FROM Categories");
        return result.ToList();
    }
}
}