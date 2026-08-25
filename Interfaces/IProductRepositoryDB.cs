using System.Threading.Tasks;
using AutoTestsForApplications.DTO;

namespace AutoTestsForApplications.Interfaces;

public interface IProductRepositoryDB
{
    Task<ProductDB> GetByIdAsync(int id);
}