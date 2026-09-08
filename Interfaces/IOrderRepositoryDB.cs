using System.Collections.Generic;
using System.Threading.Tasks;
using AutoTestsForApplications.DTO;

namespace AutoTestsForApplications.Interfaces;

public interface IOrderRepositoryDB
{
    Task<List<ProductDB>> GetProductsByOrderIdAsync(int orderId);
    Task<List<string>> GetCitiesByCategoryAsync(string categoryName);
    Task<List<int>> GetUsersWhoBoughtBothCategoriesAsync(string category1, string category2);
}