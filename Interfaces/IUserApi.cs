using Refit;
using AutoTestsForApplications.DTO;

namespace AutoTestsForApplications.Interfaces
{
    [Headers("x-api-key: free_user_3I0Gf8mCfHVlgZ0Eb2Itz1StKCf")]
    public interface IUserApi
    {
        [Get("/api/users/{id}")]
        Task<UserResponseDTO> GetUserAsync(int id);


        [Post("/api/users")]
        Task<CreateUserResponseDTO> CreateUserAsync([Body] CreateUserRequestDTO request);

        [Delete("/api/users/{id}")]
        Task<ApiResponse<string>> DeleteUserAsync(int id);
    }
}