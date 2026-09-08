using System.Collections.Generic;
using System.Threading.Tasks;
using AutoTestsForApplications.DTO;

namespace AutoTestsForApplications.Interfaces
{

    public interface ICategoryRepositoryDB
    {
        Task<List<CategoryDB>> GetAllAsync();
    }
}