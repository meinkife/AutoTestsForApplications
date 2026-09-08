using BookStore.DTO;
using BookStoreDTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Interfaces.BookStore
{
    public interface IBookStoreApi
    {
        [Post("/Account/v1/User")]
        Task<UserResponseDTO> CreateUserAsync([Body] UserCreateBodyDTO credentials);

        [Post("/Account/v1/GenerateToken")]
        Task<TokenUserResponseDTO> GenerateTokenAsync([Body] UserCreateBodyDTO credentials);

        [Post("/Account/v1/Login")]
        Task<LoginUserResponseDTO> GetUserIdAsync([Body] UserCreateBodyDTO credentials);

        [Get("/BookStore/v1/Books")]
        Task<BookListDTO> GetBookListAsync();

        [Get("/BookStore/v1/Book")]
        Task<BookDTO> GetBookByIsbnAsync([Query] string ISBN);

        [Post("/BookStore/v1/Books")]
        Task<UserResponseDTO> AddBookToUserAsync([Body] AddCollectionOfBooksToUserDTO request,
            [Header("Authorization")] string token);

        [Delete("/BookStore/v1/Book")]
        Task<DeleteBookRequestDTO> DeleteBookFromUserAsync([Body] DeleteBookRequestDTO request, [Header("Authorization")] string token);
    }
}